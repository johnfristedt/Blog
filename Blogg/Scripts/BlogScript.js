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
    console.log('click');
    $.post(
        '/Blog/PostComment',
        { content: $('#content').text }
    )
    .done(function (data) {
        console.log('Comment uploaded');
    });
});

document.querySelector('#commentauthor').disabled = true;