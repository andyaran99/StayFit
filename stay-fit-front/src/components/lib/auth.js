﻿

export function getJwtToken() {
    return localStorage.getItem("jwt")
}

export function setJwtToken(token) {
    localStorage.setItem('jwt', token.token)
}

export function getRefreshToken() {
    return localStorage.getItem("refreshToken")
}

export function setRefreshToken(token) {
   localStorage.setItem("refreshToken", token)
}

export function setButtonLogOut(){
    if(getJwtToken()!=null){
        var element= document.getElementById("login");
        element.innerHTML="Logout";
        element.addEventListener("click",logoutFunction);
    }
    else{
        console.log("Already Login")
    }
   
}

export function logoutFunction(){
    setJwtToken("jwt","");
    var element= document.getElementById("login");
    element.innerHTML="Login";
    element.removeEventListener("click",logoutFunction);
    
}




