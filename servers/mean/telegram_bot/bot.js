var token = '240115938:AAH6qGfjQZyhxMb7P2tszB-Z9ldMyBSU1EY';

var Bot = require('node-telegram-bot-api'),
    bot = new Bot(token, { polling: true }),
    movieService = require('./services/movieDbService.js');;

console.log('bot server started...');

bot.onText(/^\/sir1 (.+)$/, (msg, match) => {

    var movie_title = match[1].replace(/\s/g, '+');

    var chatId = msg.chat.id;
    // From file
    var photo = __dirname + '/public/movie.png';
    bot.sendPhoto(chatId, photo, { caption: "Hi man, let's search a movie by its Title" });

    movieService.getMovieByTitle(movie_title, (err, result) => {
        var res = result;
        var template = `
            Title: ${res.Title}
            Year:  ${res.Year}
            Rated: ${res.Rated}
            Released: ${res.Released}
            Runtime: ${res.Runtime}
            Genre:   ${res.Genre}
            Director: ${res.Director}
            Plot:     ${res.Plot}
        `;
        //bot.sendPhoto(msg.chat.id, photo, {caption: result.Title });

        bot.sendMessage(msg.chat.id, template).then(() => {
            // reply sent!
        });
    });
});