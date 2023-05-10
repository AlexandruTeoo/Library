function evaluatePasswordStrength() {
    var password = document.getElementById("psw").value;
    var strengthMeter = document.getElementById("strength-meter");
    var strengthText = document.getElementById("strength-text");

    // Verifică puterea parolei folosind reguli personalizate
    // Aici poți adăuga propriile criterii de putere a parolei
    var strength = 0;
    if (password.match(/[a-zA-Z0-9]+/)) {
        strength += 1;
    }
    if (password.match(/[~`!#$%\^&*+=\-\[\]\\';,/{}|\\":<>\?]/)) {
        strength += 1;
    }
    if (password.length >= 8) {
        strength += 1;
    }
    if (document.getElementById('psw').value === document.getElementById('rpsw').value) {
        strength +=1;
    }

    // Actualizează afișarea puterii parolei
    switch (strength) {
        case 0:
            strengthMeter.value = 0;
            strengthText.textContent = "😒";
            break;
        case 1:
            strengthMeter.value = 25;
            strengthText.textContent = "😕";
            break;
        case 2:
            strengthMeter.value = 50;
            strengthText.textContent = "😏";
            break;
        case 3:
            strengthMeter.value = 75;
            strengthText.textContent = "😎";
            break;
        case 4:
            strengthMeter.value = 100;
            strengthText.textContent = "😲";
            break;
    }
}

function onChange() {
    const password = document.querySelector('input[name=psw]');
    const confirm = document.querySelector('input[name=rpsw]');
    if (confirm.value === password.value) {
        confirm.setCustomValidity('');
    } else {
        confirm.setCustomValidity('Passwords do not match');
    }
}