// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code

var ViewModel = function() {
    console.log("View Model started")
    
    let me =  this;
    
    me.userQuery = ko.observable();
    me.returnedQuery = ko.observableArray();
    me.queryMatches = ko.observable();
    me.queryTime = ko.observable();
    me.username = ko.observable();
    me.password = ko.observable();
    
    me.init = function (){
        //check if login disabled
        const loginDisabled = false;
        if(loginDisabled) {
            document.getElementById('login-container').style.display = 'none';
        } else {
            document.getElementById('search-button').disabled = true;
        }
    }
    
    me.search = function (){
        $.ajax({
            url: "http://localhost:9020/LoadBalancer?terms=" + me.userQuery() + "&numberOfResults=10", //todo use load balancer
            success: function (data) {
                me.queryMatches(data.documents.length);
                me.queryTime(data.elapsedMilliseconds);
                me.returnedQuery.removeAll();
                data.documents.forEach( function (hit) {
                    me.returnedQuery.push(hit);
                    console.log(hit);
                });
            }
            });
    }
    
    me.login = function (){
        $.ajax({
            // url: "http://localhost:9021/User",
            url: "http://localhost:9025/UserLoadBalancer?username=" + me.username + "&password=" + me.password,

            data: {username: me.username, password: me.password},
            success: function () {
                console.log("LOGIN SUCCESSFUL");
                document.getElementById('search-button').disabled = false;
            }
        })
    }
}
// Create an instance of the view model
var viewModelInstance = new ViewModel();

// Bind the view model to the HTML view
ko.applyBindings(viewModelInstance);

// Call the init function
viewModelInstance.init();
