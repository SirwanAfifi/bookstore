var token = '254779549:AAE_LXWqxmng7TXytKlAyMt9NFgIQg8lstU';

var Bot = require('node-telegram-bot-api'),
    bot = new Bot(token, { polling: true }),
    bookService = require('./services/bookService.js'),
    moment = require('moment-jalaali'),
    fs = require('fs');

console.log('bot server started...');

var results = [];

bot.on('inline_query', function (query) {

    var book_title = match[1].replace(/\s/g, '+');

    if (book_title === "") 
        results = [];

    console.log(book_title);

    movieService.getBookByTitle(book_title, (err, result) => {

        var res = result;

        
    });


});