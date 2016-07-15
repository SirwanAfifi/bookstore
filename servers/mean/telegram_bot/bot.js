var token = '240115938:AAH6qGfjQZyhxMb7P2tszB-Z9ldMyBSU1EY';

var Bot = require('node-telegram-bot-api'),
    bot = new Bot(token, { polling: true }),
    movieService = require('./services/movieDbService.js'),
    moment = require('moment-jalaali'),
    helper = require('./services/helper.js'),
    fs = require('fs');

console.log('bot server started...');

bot.onText(/^\/sir1 (.+)$/, (msg, match) => {

    var movie_title = match[1].replace(/\s/g, '+');

    /*var chatId = msg.chat.id;
    // From file
    var photo = __dirname + '/public/movie.png';
    bot.sendPhoto(chatId, photo, { caption: "Hi man, let's search a movie by its Title" });*/

    movieService.getMovieByTitle(movie_title, (err, result) => {
        var res = result;

        console.log(result);

        var template = `
عنوان: ${res.Title}
سال:  ${res.Year}
رده‌ی سنی: ${helper.getMovieRated(res.Rated)}
تاریخ انتشار: ${moment(res.Released).format('jYYYY/jMM/jDD')}
مدت زمان: ${res.Runtime.substring(0, res.Runtime.length - 4) + "دقیقه "}
ژانر:   ${res.Genre}
کارگردان: ${res.Director}
خلاصه:     ${res.Plot}
        `;
        //bot.sendPhoto(msg.chat.id, photo, {caption: result.Title });

        bot.sendMessage(msg.chat.id, template).then(() => {
            // reply sent!
        });

        var request = require('request');
        request.get(res.Poster, function (error, response, body) {
            if (!error && response.statusCode == 200) {
                bot.sendPhoto(msg.chat.id, response, { caption: res.Title });
            }
        });
        
    });
});