const output = $('.output');
let input = $('#inputEnter');

$('#startSystem').on('click', () => {
  $('#startSystemSound').prop('volume', 0.45);
  $('#startSystemSound').trigger('play');

  bootSystemA();
});

$('#startSystemSound').on('ended', () => {
  $('#startTerminalSound').prop('volume', 0.8);
  $('#startTerminalSound').trigger('play');

  $('.bootSystemB').hide();

  setTimeout(() => {
    $('#startSystem').remove();
    $('.bootSystemA').remove();
    $('.bootSystemB').remove();

    $('body').css('padding', '200px');
    $('body').css('overflow-y', 'scroll');

    $('.welcome').show();
    $('.output').show();
    $('.osIcon').show();
    $('.input-container').css('display', 'flex');
  }, 500);
});

function addInOutput(command) {
  const newOutput = $('<div></div>').addClass('user-send-container');
  const arrow = $('<h1>></h1>');
  const textTyped = $('<p>' + dataInput + '</p>');

  newOutput.appendTo(output);
  arrow.appendTo(newOutput);
  textTyped.appendTo(newOutput);

  $('<p>' + command + '</p>')
    .addClass('console-message')
    .appendTo(output);
}

let dataInput;
$(document).on('keypress', e => {
  if (e.keyCode == 13 && input.val() != '') {
    dataInput = input.val();

    let reqFindCommand = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        Call: input.val(),
      }),
    };

    fetch('input/search', reqFindCommand)
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error ${response.status}`);
        }
        return response.json();
      })
      .then(data => {
        if (data.Output != null) addInOutput(data.Output);
        eval(data.Execute);
        
      })
      .catch(error => {
        if (error == 'Error: HTTP error 404') addInOutput('Unknown command, type --help');
      });

    input.val('');
    $(document).scrollTop(10000000000000);
  }
});

fetch('https://api.ipify.org?format=json')
  .then(response => response.json())
  .then(data => {
    $('#ipsystem').text(data.ip);
  })
  .catch(error => {
    console.log('Error to catch IP System: ', error);
    $('#ipsystem').text('FATAL ERROR');
  });

function bootSystemA() {
  setTimeout(() => {
    $('.bootSystemA').show();
  }, 1500);

  setTimeout(() => {
    $('.systemBootA-A').show();
  }, 3000);

  setTimeout(() => {
    $('.systemBootA-B').show();
  }, 4200);

  const textDetectingBoot = document.querySelectorAll('.detectingBoot');
  textDetectingBoot.forEach(() => {
    setTimeout(() => {
      $(textDetectingBoot[0]).removeClass('animationUnderScore');
      textDetectingBoot[0].innerHTML = 'OK';
    }, 5000);
    setTimeout(() => {
      $(textDetectingBoot[1]).removeClass('animationUnderScore');
      textDetectingBoot[1].innerHTML = 'OK';
    }, 5900);
    setTimeout(() => {
      $(textDetectingBoot[2]).removeClass('animationUnderScore');
      textDetectingBoot[2].innerHTML = 'OK';
    }, 6800);
  });

  setTimeout(() => {
    $('.bootSystemA').hide();

    bootSystemB();
  }, 7500);
}

function bootSystemB() {
  $('body').css('overflow-y', 'hidden');
  $('.bootSystemB').show();

  setTimeout(() => {
    $('.systemBootB-B').show();
    let i = 0;
    const addDots = setInterval(() => {
      i++;
      $('.systemBootB-B').text($('.systemBootB-B').text() + '.');
      if (i == 6) {
        clearInterval(addDots);
      }
    }, 200);
  }, 1500);

  setTimeout(() => {
    $('.systemBootB-C').css('display', 'flex');
  }, 3500);
}
