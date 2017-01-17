const assert = require('assert');

function getAnimals(fetch, id) {
    return fetch('http://apianimalfarmgame.com/animals/' + id)
        .then(response => response.json())
        .then(data => data.results[0]);
}

getMovieRated = rated => {
        var str = "";
        switch (rated) {
            case "R":
                str = "+17";
                break;
             case "PG-13":
                str = "+13";
                break;
            case "NC-17":
                str = "+17";
                break;
            case "PG":
                str = "عمومی";
                break;
            case "G":
                str = "عمومی";
                break;
            default:
                str = "تعیین نشده";
                break;
        }
        return str;
    };

/*
{
    results: [
        {
            name: 'cat',
            type: 'what?'
        }
    ]
}
*/

describe('getAnimals', () => {
    it('calls fetch with correct url', () => {

        //assert([1, 2, 3, 4, 6].length === 4);

        const fakeFetch = url => {
            assert('http://apianimalfarmgame.com/animals/123' === url);

            return new Promise((resolve) => { });

        };

        getAnimals(fakeFetch, 123);

    })

    it('parses the response of fetch correctly', (done) => {
        const fakeFetch = url => {
            return Promise.resolve({
                json: () => Promise.resolve({
                    results: [
                        {
                            name: 'cat',
                            type: 'what?'
                        }
                    ]
                })
            })
        }

        getAnimals(fakeFetch, 123)
            .then(result => {
                assert(result.name === 'cat')
                done()
            });
    })

    it('gets proper movie rate', () => {

        assert(getMovieRated('R') === '+17')

    })
})