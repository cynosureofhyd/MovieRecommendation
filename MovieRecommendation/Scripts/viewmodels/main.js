$.ajax({
    type: "POST",
    url: 'api/Main',
    data: {start:1, end:100},
    success: success,
    dataType: dataType
});