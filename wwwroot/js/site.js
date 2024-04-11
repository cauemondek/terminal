const output = $('.output');

function addInOutput() {
    const newOutput = $('<div></div>').addClass('input-container');
    const arrow = $('<h1>></h1>');
    const textTyped = $('<p>'+ $('#inputEnter').val() + '</p>');

    newOutput.appendTo(output);
    arrow.appendTo(newOutput);
    textTyped.appendTo(newOutput);
}




