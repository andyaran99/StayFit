import crypto from "crypto";
import stream from "stream";





export function getJwtToken() {
    return localStorage.getItem("jwt")
}

export function setJwtToken(token) {
    localStorage.setItem("jwt", token)
}

export function getRefreshToken() {
    return localStorage.getItem("refreshToken")
}

export function setRefreshToken(token) {
   localStorage.setItem("refreshToken", token)
}

export function setButtonLogOut(){
    document.getElementById("login")
}

