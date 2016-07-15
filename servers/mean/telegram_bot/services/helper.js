(function (helper) {

    helper.getMovieRated = function (rated) {
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

})(module.exports);