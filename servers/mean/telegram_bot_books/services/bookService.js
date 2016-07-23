(goodReadsService =>{

    var http   = require('http'),
        xml2js = require('xml2js')
        parser = xml2js.Parser({ explicitArray : false });
    
    goodReadsService.getBookByTitle = (title, next) => {
        
        var options = {
            host: 'www.goodreads.com',
            path: `/search/index.xml?key=9pfr0A8xcuDF8axzFCcaCg&q=${title}`
        };

        var callback = response => {
            var str= '';

            response.on('data', chuck => {
                str += chuck;
            });

            response.on('end', () => {
                parser.parseString(str, (err, result) => {
                    var res = result.GoodreadsResponse.search.results.work;
                    next(null, res);
                });
            });
        };

        http.request(options, callback).end();
    };

}) (module.exports);