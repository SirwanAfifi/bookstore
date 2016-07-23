var token = '254779549:AAE_LXWqxmng7TXytKlAyMt9NFgIQg8lstU';

var Bot = require('node-telegram-bot-api'),
    bot = new Bot(token, { polling: true }),
    movieService = require('./services/bookService.js'),
    moment = require('moment-jalaali'),
    fs = require('fs');

console.log('bot server started...');

var results = [];

bot.on('inline_query', function (query) {

    var book_title = query.query.replace(/\s/g, '+');

    console.log(book_title);

    if (book_title === "")
        results = [];

    console.log(book_title);

    if (book_title != undefined) {
        movieService.getBookByTitle(book_title, (err, result) => {

            var res = result;

            console.log(res);

            if (res != undefined) {
                res.forEach(function (item) {
                    var number = Math.floor(Math.random() * 64) + 1;
                    var template = `
عنوان: ${item.best_book.title}
نویسنده: ${item.best_book.author.name}
امتیاز:  ${item.ratings_count}
        `;
                    console.log(item);
                    results.push({
                        type: "photo",
                        id: number.toString(),
                        photo_url: item.best_book.small_image_url.toString(),
                        thumb_url: item.best_book.small_image_url.toString(),
                        title: item.best_book.title,
                        description: item.best_book.title,
                        caption: item.best_book.title,
                        input_message_content: {
                            message_text: template
                        }
                    });
                    bot.answerInlineQuery(query.id, results);
                }, this);
            }

            /*var number = Math.floor(Math.random() * 64) + 1;
    
            results.push({
                type: "photo",
                id: number.toString(),
                photo_url: image.toString(),
                thumb_url: image.toString(),
                title: "",
                description: "",
                caption: "",
                input_message_content: {
                    message_text: template
                }
            });
            bot.answerInlineQuery(query.id, results);*/
        });
    }


});