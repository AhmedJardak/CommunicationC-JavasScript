function bindEvent(element, eventName, eventHandler) {
    if (element.addEventListener) {
        element.addEventListener(eventName, eventHandler, false);
    } else if (element.attachEvent) {
        element.attachEvent('on' + eventName, eventHandler);
    }
}

CSharpToJavaScript = function (data) {

    var person = JSON.parse(data);
    $('#sample').text("execute From C# a javascript function:" + person.Name + " " + person.Password);
};

InvokeFunctionReturnData = function (data) {
    var person = JSON.parse(data);
    $('#sample').text("return Data Function:" + person.Name + " " + person.Password);
}


function ExecuteSampleFunction() {
    var person = { name: "name", password: "password" }
    InvokeFunction(JSON.stringify(person));
    $('#sample').text("execute From  javascript a C# function");
}
