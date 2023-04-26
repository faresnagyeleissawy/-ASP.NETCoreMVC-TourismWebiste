﻿//GIS implementation
//creat map//
function CreateMap() {
    const map = new ol.Map({
        controls: ol.control.defaults
            .defaults()
            .extend([new ol.control.FullScreen()]),
        target: "map",
        view: new ol.View({
            center: [3600000, 3000000],
            zoom: 5,
        }),
        layers: [],
    });
    CreatePopup(map);
    return map;
}
function changebasemap(map) {
    const osmLayer = new ol.layer.Tile({
        source: new ol.source.OSM(),
        visible: false,
        title: "OSM",
        layerName: "OSMbase",
    });

    const worldImagery = new ol.layer.Tile({
        source: new ol.source.XYZ({
            url: "https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}",
            maxZoom: 19,
        }),
        visible: true,
        title: "Esri",
        layerName: "ESRIbase",
    });
    map.addLayer(osmLayer);
    map.addLayer(worldImagery);
    const baseMapSelector = document.querySelector(".basemapselector");
    baseMapSelector.addEventListener("change", function (e) {
        const mapTitle = e.target.value;
        const baseMaps = [osmLayer, worldImagery];
        baseMaps.forEach((base) => {
            if (base.getProperties().title === mapTitle) {
                base.setVisible(true);
            } else {
                base.setVisible(false);
            }
        });
    });
}
/// shortage name
function shortNameMaking(str) {
    const parts = str.split(",");
    const result = parts.slice(0, 2).concat(parts[parts.length - 2]);
    return result.join(",");
}
//geocoding//
function getGeocondingData(searchInput) {
    return fetch(
        "https://nominatim.openstreetmap.org/search?q=" +
        searchInput +
        "&format=geojson"
    )
        .then((res) => res.json())
        .then((data) => {
            return data;
        });
}
function Geocoding(map) {
    const pinLayer = new ol.layer.Vector({
        source: new ol.source.Vector(),
        title:"PinLocation"
    });
    map.addLayer(pinLayer);
    let timer;
    let searchbox = document.querySelector("#searchbox");
    let searchList = document.querySelector("#placeopetion");
    searchbox.addEventListener("input", (e) => {
        let text = e.target.value;
        clearTimeout(timer);
        timer = setTimeout(() => {
            let dataPromise = getGeocondingData(text);
            dataPromise.then((data) => {
                searchList.innerHTML = "";
                data.features.forEach((f) => {
                    let name = f.properties.display_name;
                    let li = document.createElement("li");
                    li.innerHTML = shortNameMaking(name);
                    li.id = f.properties.osm_id;

                    li.addEventListener("click", (e) =>
                        clickPlaceListHandeler(e, data.features)
                    );
                    searchList.append(li);
                });
            });
        }, 500);
    });
  let pinLocation;
  function clickPlaceListHandeler(e, features) {
            let id = e.target.id;
            let feature = features.find((feature) => feature.properties.osm_id == id);
            let coords = ol.proj.transform(
                feature.geometry.coordinates,
                "EPSG:4326",
                "EPSG:3857"
            );
            map.getView().animate({ zoom: 12 }, { center: coords });
            pinLayer.getSource().removeFeature(pinLocation);
            pinLocation = new ol.Feature({
                geometry: new ol.geom.Point(coords),
            });
            pinLocation.setStyle(
                new ol.style.Style({
                    image: new ol.style.Circle({
                        radius: 7,
                        //fill: new ol.style.Fill({
                        //    color: color,
                        //}),
                        stroke: new ol.style.Stroke({
                            color: "Black",
                            width: 4
                        })
                    })
                })
            );
      pinLayer.getSource().addFeature(pinLocation);
     
    }
   
};
//creat feature from data//
function creatFeatures(features, color, name) {


    let listFeatures = [];
    features.forEach(function (data) {


        let lat = data.X;
        let lon = data.Y;
        let name = data.Name;
        let image = data.Image;
        let rate = data.Rate;
      
       

        let feature = new ol.Feature({
            geometry: new ol.geom.Point(
                ol.proj.transform([lon, lat], "EPSG:4326", "EPSG:3857")
            ),
            name,
           
            image,
            rate,

        });
        listFeatures.push(feature);
   
       
       

    });
  

    let AccomdationLayerSource = new ol.source.Vector({
        features: listFeatures,
    });

    let AccodationLayer = new ol.layer.Vector({
        source: AccomdationLayerSource,

        style: new ol.style.Style({
            image: new ol.style.Circle({
                radius: 7,
                //fill: new ol.style.Fill({
                //    color: color,
                //}),
                stroke: new ol.style.Stroke({
                    color: color,
                    width: 4
                })
            })
        }),
        title:name,
    });
  
  
   
    
    return AccodationLayer;

}
//check box
function creatLayerListHandelCheckBox(map) {
    var layers = map.getLayers().getArray();
  
    for (var i = 3; i < layers.length; i++) {
        let layer = layers[i]
        let layername = layers[i].get('title');

        let li = '<li><label><input type="checkbox" checked id="' + i + '" name="' + layername + '" value="' + layername + '">' + layername + '</label></li>'

        document
            .querySelector("#checkbox-list")
            .insertAdjacentHTML("afterend", li);
        let checkbox = document.getElementById(i);

        checkbox.addEventListener('change', function () {
            if (this.checked) {
                layer.setVisible(true);
            } else {
                layer.setVisible(false);
            }
        });


    }

}
//popup 
function CreatePopup(map) {
    const popup = new ol.Overlay({
        element: document.querySelector(".pop"),
    });
    map.addOverlay(popup);

    const name = document.querySelector("#name");
    const description = document.querySelector("#description");
    let image = document.querySelector("#image").getAttribute("src");
   

    map.on("click", (e) => {
        const feature = map.forEachFeatureAtPixel(e.pixel, (feature) => {
            return feature;
        });

        if (feature) {
            popup.setPosition(e.coordinate);
            document.querySelector(".pop").style.display = "block";
            name.innerHTML = feature.get("name");
            description.innerHTML = feature.get("description");
            image = `"./Images/${feature.get("#image")}"`;
            console.log(image);
        } else {
           
            document.querySelector(".pop").style.display = "none";
        }
    });

   
}

function ClearLayers() {
   var layers = [...map.getLayers().getArray()]
    // var layers = map.getLayers().getArray();
  
    for (var i = 0; i < layers.length; i++) {
        const layer = layers[i];
        const title = layer.get('title');
        if (title !== "Esri" && title !== "OSM" && title !== "PinLocation") {
            map.removeLayer(layer);
           
        }
      
      
    }
   
}
