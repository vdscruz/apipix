import http from 'k6/http';
import { check, sleep } from 'k6';
import variables from '../config/variables.js'

const path = '/loc';

const params = {
    headers: {
      'Content-Type': 'application/json',
    },
  };

function GetLocationById(id) {
    const res = http.get(`${variables.host}${path}/${id}`);
    check(res, { 'status was 200': (r) => r.status == 200 });
}

function CreateLocation(type) {
    const payload =  JSON.stringify({ tipoCob: type });
    const res = http.post(`${variables.host}${path}`, payload, params);
    check(res, { 'status was 201': (r) => r.status == 201 });
}

export {
    GetLocationById,
    CreateLocation
}