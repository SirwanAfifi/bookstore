(function (movieDbService) {

    var http   = require('http');

    movieDbService.getMovieByTitle = function (title, next) {

        var options = {
            host: 'omdbapi.com',
            path: `/?t=${title}&y=&plot=short&r=json`
        };

        var callback = function (response) {
            var str = '';

            response.on('data', function (chunk) {
                str += chunk;
            });
            response.on('end', function () {
                var result = JSON.parse(str);
                next(null, result);
            });
        };

        http.request(options, callback).end();
    };

}) (module.exports);