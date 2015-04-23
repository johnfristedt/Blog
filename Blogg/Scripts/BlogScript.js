/// <reference path="jquery-2.1.3.js" />
var postCount = 1

$('#moreposts').click(function () {
    $.get(
        '/Blog/GetPosts',
        { id: postCount }
    )
    .done(function (data) {
        $('#blog').append(data);
        postCount++;
    });
});

$('#post-comment').click(function () {
    $('.static-parameter').prop('disabled', false);
    $.post(
        '/Blog/PostComment',
        $('#comment-form').serialize()
    )
    .done(function (data) {
        console.log('Comment uploaded');
    });
    $('.static-parameter').prop('disabled', true);
});

$('.static-parameter').prop('disabled', true);