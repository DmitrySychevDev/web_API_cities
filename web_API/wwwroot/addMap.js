
let mapElem;
function initMAp()
{
    google.maps.visualRefresh=true;
    const Moscow = new google.maps.LatLng(55.752622, 37.617567);
    const mapOptions = {
        zoom: 5,
        center: Moscow,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };
    const elem=document.getElementById("convas");
    mapElem=new google.maps.Map(elem,mapOptions);
    const LatLng=new google.maps.LatLng(55.752622, 37.617567);
    new google.maps.Marker({
        position: LatLng,
        map: mapElem,
    });

}
let getRussianMap=async ()=>{

    let response = await fetch("https://localhost:5001/api/Cities");
	console.log(response);
    if (response.ok) { // если HTTP-статус в диапазоне 200-299
        // получаем тело ответа (см. про этот метод ниже)
        let json = await response.json();
        json.forEach((city)=>{
            const cityLocation = new google.maps.LatLng(city.coords.lat, city.coords.lon);

            let marker = new google.maps.Marker({
                position: cityLocation,
                map: mapElem,
                title: city.name
            });
            const info=`<div><h2>${city.name}</h2><div><h4>Население:${city.population}</h4></div><div><h4>Субъект:${city.subject}</h4><div><h4>Район:${city.district}</h4></div></div>`
            const infowindow = new google.maps.InfoWindow({
                content:info,
            });

            google.maps.event.addListener(marker, 'click',function clickEvent(){
    infowindow.open(mapElem,marker)
});
            marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png');
        });
    } else {
        alert("Ошибка HTTP: " + response.status);
    }
}
initMAp();
getRussianMap();