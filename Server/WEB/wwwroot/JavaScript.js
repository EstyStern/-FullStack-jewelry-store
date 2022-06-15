const name = document.getElementById("UserName");
const pass = document.getElementById("pass");
const btn = document.getElementById("btnLog");

//all person
async function func1() {
    var raw = "";

    var requestOptions = {
        method: 'GET',
        //body: raw,
        redirect: 'follow',
        mode: 'no-cors',
        // dataType: "json"
        // headers:{Accept: 'application/json',
        // 'Content-Type': 'application/json'}
    };

    let response = await fetch("https://localhost:44312/api/User/GetAllUsers", requestOptions);
    let data = response.json();
    await (result => {
        console.log("hhh");
        console.log(result)
    });
    console.log(data)

}

 //GET PERSON BY userName AND password
async function func2() {
    var raw = "";

    var requestOptions = {
        method: 'GET',
        //body: raw,
        redirect: 'follow',
        mode: 'no-cors',
        // dataType: "json"
        // headers:{Accept: 'application/json',
        // 'Content-Type': 'application/json'}
    };

    let response = await fetch("https://localhost:44312/api/User/GetAllUsers" + "'&name='" + name + "'&pass='" + pass + "'", requestOptions);
    //"'api/User/GetUserByNameAndPass?'" + "'&name='" + name + "'&pass='" + pass + "'"
    let data = response.json();
    await (result => {
        console.log("hhh");
        console.log(result)
    });
    console.log(data)

}

      
//function func1()
//{

//    $.ajax({
//        type: "GET",
//        contentType: "application/json; charset=utf-8",
//        "headers": { 'Authorization': 'Bearer ' + sessionStorage.getItem('token') },
//        //basicUrl/spesipicUrl/
//        //< baseUrl > <track>?username=rachel&pass=123
//        //localhost:51565\Users\Login?username=rachel&pass=123

//        //???
//        url: "'api/User/GetUserByNameAndPass?'" + "'&name='" + name + "'&pass='" + pass + "'",
//        //???

//        dataType: "json",
//        success: function (result) {
//            if (!($.isArray(result) && result.length == 0))
//                $($this).parent().html(InitGeoJsonSelect(result));
//            else {
//                alert('Address not found!');
//                $($this).val('Cannot Get');
//                $($this).prop('disabled', true);
//            }
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            console.log(textStatus + ': ' + errorThrown);
//        }
//    });
//}


//const func3 = () => {
//    var settings = {
//        "url": "https://localhost:44312/api/User/GetAllUsers",
//        "method": "GET",
//        "timeout": 0,
//        "mode": 'no-cors',
//        "dataType": "json"
//    };

//    $.ajax(settings).done(function (response) {
//        debugger;
//        console.log(response);
//    });
//}




////GET ALL PERSON

////var myHeaders = new Headers();
////myHeaders.append("Content-Type", "application/json");

////var raw = JSON.stringify({
////    "codeProducts": 1,
////    "nameProducts": "dolly",
////    "priceProduct": 90,
////    "categoriesCode": 1234,
////    "image": "stock-vector-illustration-of-a-cute-little-girl-wearing-a-princess-costume-194642240.jpg"
////});

////var requestOptions = {
////    method: 'GET',
////    headers: myHeaders,
////    body: raw,
////    redirect: 'follow'
////};

////function func2() {
////    fetch("https://localhost:44312/api/User/GetAllUsers", requestOptions)
////        .then(response => response.text())
////        .then(result => console.log(result))
////        .catch(error => console.log('error', error));
////}
btn.onclick = func1();