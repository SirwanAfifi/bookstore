var token = '240115938:AAH6qGfjQZyhxMb7P2tszB-Z9ldMyBSU1EY';

var Bot = require('node-telegram-bot-api'),
    bot = new Bot(token, { polling: true }),
    movieService = require('./services/movieDbService.js'),
    moment = require('moment-jalaali'),
    helper = require('./services/helper.js'),
    fs = require('fs');

console.log('bot server started...');



bot.onText(/^\/movie (.+)$/, (msg, match) => {

    var movie_title = match[1].replace(/\s/g, '+');

    movieService.getMovieByTitle(movie_title, (err, result) => {

        if (err) {
            bot.sendMessage(msg.chat.id, 'بوخشه مشکله پیش هاتگه!').then(() => {
                // reply sent!
            });
        }

        var res = result;

        var title = res.Title != undefined && res.Title != 'N/A' ? res.Title : 'ثبت نشده';
        var genre = res.Genre != undefined && res.Genre != 'N/A' ? res.Genre.split(',') : 'ثبت نشده';
        var rated = res.Rated != undefined && res.Rated != 'N/A' ? helper.getMovieRated(res.Rated) : 'ثبت نشده';
        var released = res.Released != undefined && res.Released != 'N/A' ? moment(res.Released).format('jYYYY/jMM/jDD') : 'ثبت نشده';
        var runtime = res.Runtime != undefined && res.Runtime != 'N/A' ? res.Runtime.substring(0, res.Runtime.length - 4) + "دقیقه " : 'ثبت نشده';

        var template = `
عنوان: ${res.Title}
امتیاز: ${res.imdbRating}
سال:  ${res.Year}
رده‌ی سنی: ${rated}
تاریخ انتشار: ${released}
مدت زمان: ${runtime}
ژانر:   ${genre}
کارگردان: ${res.Director}
خلاصه:     ${res.Plot}
لینک: http://www.imdb.com/title/${res.imdbID}
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


bot.onText(/^\/book (.+)$/, (msg, match) => {

    var book_title = match[1].replace(/\s/g, '+');


});

var results = [];

bot.on('inline_query', function (query) {

    var movie_title = query.query.replace(/ /g,"+");

    if (movie_title === "") 
        results = [];

    console.log(movie_title);

    movieService.getMovieByTitle(movie_title, (err, result) => {

        var res = result;

        var title = res.Title != undefined && res.Title != 'N/A' ? res.Title : 'ثبت نشده';
        var genre = res.Genre != undefined && res.Genre != 'N/A' ? res.Genre.split(',') : 'ثبت نشده';
        var rated = res.Rated != undefined && res.Rated != 'N/A' ? helper.getMovieRated(res.Rated) : 'ثبت نشده';
        var released = res.Released != undefined && res.Released != 'N/A' ? moment(res.Released).format('jYYYY/jMM/jDD') : 'ثبت نشده';
        var runtime = res.Runtime != undefined && res.Runtime != 'N/A' ? res.Runtime.substring(0, res.Runtime.length - 4) + "دقیقه " : 'ثبت نشده';

        var template = `
عنوان: ${res.Title}
امتیاز: ${res.imdbRating}
سال:  ${res.Year}
رده‌ی سنی: ${rated}
تاریخ انتشار: ${released}
مدت زمان: ${runtime}
ژانر:   ${genre}
کارگردان: ${res.Director}
خلاصه:     ${res.Plot}
لینک: http://www.imdb.com/title/${res.imdbID}
        `;
        console.log(result);
        if (res.Title != undefined && res.Poster != "N/A") {
            var number = Math.floor(Math.random() * 64) + 1;
            console.log(result);
            results.push({
                type: "photo",
                id: number.toString(),
                photo_url: res.Poster,
                thumb_url: res.Poster,
                title: res.Title,
                description: "",
                caption: res.Title,
                input_message_content: {
                    message_text: template
                }
            });
            bot.answerInlineQuery(query.id, results);
        } else {

        }

    });


});