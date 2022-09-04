import { GetLocationById, CreateLocation } from './endpoints/location.js'

export const options = {
  stages: [
    { duration: '10s', target: 50 },
  ],
  thresholds: {
    http_req_failed: ['rate<0.01'], // http errors should be less than 1%
    http_req_duration: ['p(95)<200'], // 95% of requests should be below 200ms
    http_req_duration: ['p(90) < 400', 'p(95) < 800', 'p(99.9) < 2000'], // 90% of requests must finish within 400ms, 95% within 800, and 99.9% within 2s.
  },
};

export default function () {
    // GetLocationById(1);
    CreateLocation('cob');
  }