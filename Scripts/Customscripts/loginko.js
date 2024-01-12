function LoginViewmodel() {

    var self = this;

    self.username = ko.observable("");
    self.password = ko.observable("")
    
    loginclk = function () {
        var payload = {
            username: self.username(),
            password: self.password()
        }

        
    }
}
ko.applyBindings(new LoginViewmodel());