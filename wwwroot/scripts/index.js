
export function showAlert(obj) {
    const message = 'Name is ' + obj.name + ' Age is ' + obj.age;
    alert(message);
}

export function emailRegistration(message) {
    const result = prompt(message);
    if (result === '' || result === null) {
        return 'Please provide an email'
    }

    const returnMessage = 'Hi ' + result.split('@')[0] + ' your email: ' + result + ' has been accepted.';
    return returnMessage;
    

}