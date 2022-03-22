const fullNameField = document.getElementById("FullName"),
    fullNameErrorField = document.getElementById("fName"),
    fullNameErrorMessage = 'Please enter full name.',
    emailAddressField = document.getElementById("EmailAddress"),
    emailAddressErrorField = document.getElementById("eAddress"),
    emailAddressErrorMessage = 'Please enter email address.',
    phoneNumberField = document.getElementById("PhoneNumber"),
    phoneNumberErrorField = document.getElementById("pNumber"),
    phoneNumberErrorMessage = 'Please enter phone number.';

// Checks form's input values validation after mouse clicking
function isValid(event) {
    debugger;

    let isValid = true;

    if (fullNameField.value.length == 0) {
        fullNameErrorField.innerText = fullNameErrorMessage;

        isValid = false;
    }

    if (emailAddressField.value.length == 0) {
        emailAddressErrorField.innerText = emailAddressErrorMessage;

        isValid = false;
    }

    if (phoneNumberField.value.length == 0) {
        phoneNumberErrorField.innerText = phoneNumberErrorMessage;

        isValid = false;
    }

    return isValid;
}

// Checks form's input values validation after key pressing
function keyUp(event) {

    console.log(event.srcElement);

    if (event.srcElement == fullNameField) {
        fullNameErrorField.innerText = event.target.value.length > 0 ? '' : fullNameErrorMessage;
    }

    if (event.srcElement == emailAddressField) {
        emailAddressErrorField.innerText = event.target.value.length > 0 ? '' : emailAddressErrorMessage;
    }

    if (event.srcElement == phoneNumberField) {
        phoneNumberErrorField.innerText = event.target.value.length > 0 ? '' : phoneNumberErrorMessage;
    }
}