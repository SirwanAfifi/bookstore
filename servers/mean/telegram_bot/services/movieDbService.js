(movieDbService => {

    var http   = require('http');

    movieDbService.getMovieByTitle = (title, next) => {

        var options = {
            host: 'omdbapi.com',
            path: `/?t=${title}&y=&plot=short&r=json`
        };

        var callback = (response) => {
            var str = '';

            response.on('data', (chunk) => {
                str += chunk;
            });
            response.on('end', () => {
                var result = JSON.parse(str);
                next(null, result);
            });
        };

        http.request(options, callback).end();
    };

}) (module.exports);