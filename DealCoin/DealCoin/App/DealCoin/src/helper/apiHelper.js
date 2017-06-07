import $ from 'jquery'
import AuthService from '../services/AuthService'

function dataFilter(data, type) {
    if(data === '') return null;
    return data;
}

export async function postAsync(url, data) {
    console.log("POST :".JSON.stringify(data));
    return await $.ajax({
        method: 'POST',
        url: url,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${AuthService.accessToken}`
        }
    });
}

export async function putAsync(url, data) {
    console.log("PUT :".JSON.stringify(data));
    return await $.ajax({
        method: 'PUT',
        url: url,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${AuthService.accessToken}`
        }
    });
}

export async function getAsync(url) {
    console.log("GET :".JSON.stringify(data));
    return await $.ajax({
        method: 'GET',
        url: url,
        dataType: 'json',
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${AuthService.accessToken}`
        }
    });
}

export async function deleteAsync(url) {
    console.log("DELETE :".JSON.stringify(data));
    return await $.ajax({
        method: 'DELETE',
        url: url,
        dataType: 'json',
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${AuthService.accessToken}`
        }
    });
}