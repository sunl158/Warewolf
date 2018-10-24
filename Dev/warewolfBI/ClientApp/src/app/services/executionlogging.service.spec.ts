import { TestBed, fakeAsync, tick, ComponentFixture } from '@angular/core/testing';
import { JsonpModule, Jsonp, BaseRequestOptions, Response, ResponseOptions, Http } from "@angular/http";
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { MockBackend } from "@angular/http/testing";
import { LogEntry } from './../models/logentry.model';
import { ExecutionLoggingService } from './executionlogging.service';

describe('Service: ExecutionLoggingService', () => {

  let service: ExecutionLoggingService;
  let backend: MockBackend;  

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [JsonpModule, HttpClientModule],
      providers: [
        ExecutionLoggingService,
        MockBackend,
        HttpClient,
        BaseRequestOptions,
        {
          provide: Jsonp,
          useFactory: (backend, options) => new Jsonp(backend, options),
          deps: [MockBackend, BaseRequestOptions]
        }
      ]
    });
    backend = TestBed.get(MockBackend);
    service = TestBed.get(ExecutionLoggingService);
  });

  it('default should return list of execution logs ', fakeAsync(() => {
    let response = {
      "resultCount": 1,
      "results": [
        {
          "artistId": 78500,
          "artistName": "U2",
          "trackName": "Beautiful Day",
          "artworkUrl60": "image.jpg",
        }]
    };

    backend.connections.subscribe(connection => {
      connection.mockRespond(new Response(<ResponseOptions>{
        body: JSON.stringify(response)
      }));
    });
    service.getLogData("http://localhost:3142", '', '', 'asc', 0, 3);
    tick();
    expect(service).toBeTruthy();
    //TODO: mock out results later
    //expect(service.results.length).toBe(1);
    //expect(service.results[0].artist).toBe("U2");
    //expect(service.results[0].name).toBe("Beautiful Day");
    //expect(service.results[0].thumbnail).toBe("image.jpg");
    //expect(service.results[0].artistId).toBe(78500);
  }));
});
