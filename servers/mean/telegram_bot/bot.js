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

    movieService.getMovieByTitle(movie_title, (err, result) => {

        if (err) {
            bot.sendMessage(msg.chat.id, 'بوخشه مشکله پیش هاتگه!').then(() => {
                // reply sent!
            });
        }

        var res = result;

        var genre = res.Genre != undefined ? res.Genre.split(',') : '-';
        var rated = res.Rated != undefined ? helper.getMovieRated(res.Rated) : '-';
        var released = res.Released != undefined ? moment(res.Released).format('jYYYY/jMM/jDD') : '-';
        var runtime = res.Runtime != undefined ? res.Runtime.substring(0, res.Runtime.length - 4) + "دقیقه " : '-';

        var template = `
عنوان: ${res.Title}
سال:  ${res.Year}
رده‌ی سنی: ${rated}
تاریخ انتشار: ${released}
مدت زمان: ${runtime}
ژانر:   ${genre}
کارگردان: ${res.Director}
خلاصه:     ${res.Plot}
        `;

        if (res.Title != undefined) {
            bot.sendMessage(msg.chat.id, template).then(() => {
                // reply sent!
            });
        } else {
            bot.sendMessage(msg.chat.id, 'ئه‌و ناوه اشتباه‌س عزیز - خوا مالت‌‌آوا کات').then(() => {
                // reply sent!
            });
        }

    });
});
