# SimpleHttp
This is a simple http status code response site.  Pass a status code as a path and get a response with that status code.  This is useful for testing webhook requests that expect a certain status code in the response to prevent subsequent requests.

## Run from Docker
```
docker run -p 80:80 willbrowning/simplehttp
```

## Expose with ngrok
Use [ngrok](https://ngrok.com/) to proxy requests from an external generated url to the container.
```
ngrok http 80
```