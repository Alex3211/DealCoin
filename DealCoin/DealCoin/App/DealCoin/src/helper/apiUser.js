import AuthService from '../services/AuthService'
import $ from 'jquery'

function dataFilter(data, type) {
    if(data === '') return null;
    return data;
}

export async function postAsync(endpoint, id, token, data) {
 //   console.log(JSON.stringify(data));
    return await $.ajax({
        method: 'POST',
        url: endpoint.concat('/', id),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${token}`
        }
    });
}

// export async function postRAsync(endpoint, token, data) {
//  //   console.log(JSON.stringify(data));
//     return await $.ajax({
//         method: 'POST',
//         url: endpoint,
//         dataType: 'json',
//         contentType: 'application/json; charset=utf-8',
//         data: JSON.stringify(data),
//         dataFilter: dataFilter,
//         headers: {
//             Authorization: `Bearer ${token}`
//         }
//     });
// }

export async function postArticleAsync(url, data) {
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

export async function putRAsync(endpoint, token, data) {
    return await $.ajax({
        method: 'PUT',
        url: endpoint,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${token}`
        }
    });
}

export async function putAsync(endpoint, id, token, data) {
    return await $.ajax({
        method: 'PUT',
        url: endpoint.concat('/', id),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${token}`
        }
    });
}

export async function putArticleAsync(endpoint, id, token, data) {
    return await $.ajax({
        method: 'PUT',
        url: endpoint,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${token}`
        }
    });
}

export async function getAsync(endpoint, id, token) {
    return await $.ajax({
        method: 'GET',
        url: endpoint.concat('/', id),
        dataType: 'json',
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${token}`
        }
    });
}

export async function getArticleAsync(url,token) {
    return await $.ajax({
        method: 'GET',
        url: url,
        dataType: 'json',
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${token}`
        }
    });
}

export async function deleteAsync(endpoint, id, token) {
    return await $.ajax({
        method: 'DELETE',
        url: endpoint.concat('/', id),
        dataType: 'json',
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${token}`
        }
    });
}

export async function getAsyncSelect(endpoint, method, token) {
    return await $.ajax({
        method: 'GET',
        url: endpoint.concat('/', method),
        dataType: 'json',
        dataFilter: dataFilter,
        headers: {
            Authorization: `Bearer ${token}`
        }
    });
}