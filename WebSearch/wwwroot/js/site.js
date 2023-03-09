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
    
    me.search = function (){
        $.ajax({
            url: "https://localhost:9000/Search?terms=" + me.userQuery() + "&numberOfResults=10", //todo use load balancer
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
}
ko.applyBindings(new ViewModel());
