//regular expressions for input validation
function check(x) {
    var text = $("#"+x).val();
    var pattern;
    switch(x) {
        case "Email":
            pattern = /[a-zA-z0-9]{1,}@[a-zA-z0-9]{1,}.[a-zA-z0-9]{1,}/;
            if (!(pattern.test(text))) {
                return "Please enter a valid email address.";
            }
            break;
        case "UserName":
            case "FirstName":
            pattern = /^[a-zA-Z]{1,}$/;
            if (!(pattern.test(text))) {
                return "Please use alphanumerics only for names";
            }
            break;
        case "Password":
            pattern = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/;
            if (!(pattern.test(text))) {
                return "Please use at least one upper-case, lowe-case, digit, and a sign for the password";
            }
            break;
        case "ConfirmPassword":
            if (text !== $("#Password").val()) {
                return "Passwords do not match";
            }
            break;
        case "PhoneNumber":
            pattern = /^[0-9]{3}-[0-9]{7}$/;
            if (!(pattern.test(text))) {
                return "Please use the following pattern for the phone number: xxx-xxxxxxx";
            }
            break;
        default:
            console.error(x +" has no case in InputValidation");
            break;
    }
    return null;
}

//display input errors based on regular expression tests
function validationDisplay() {
    $("#errorList").empty();
    $("#ValidationSummary").show();
    var errors = [check("Email"), check("Password"), check("UserName"), check("FirstName"), check("ConfirmPassword"), check("PhoneNumber")];
    for (var i in errors) {
        if (errors.hasOwnProperty(i)) {
            if (errors[i] != null) {
                $("#errorList").append("<li>" + errors[i] + "</li>");
            }
        }
    }
}