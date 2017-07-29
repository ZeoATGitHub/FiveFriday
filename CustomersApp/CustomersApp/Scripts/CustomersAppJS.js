$(document).ready(function () {

var ViewModel = function () {
    var self = this;
    self.customers = ko.observableArray();
    self.error = ko.observable();
    self.contacts = ko.observableArray();
    var customersLink = '/api/Main_Customer/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllCustomers() {
        ajaxHelper(customersLink, 'GET').done(function (data) {
            self.customers(data);
            

        });
    }

    // Fetch the initial data.
    getAllCustomers();

    self.detail = ko.observable();

    self.getMainCustomer = function (item) {
        ajaxHelper(customersLink + item.Id, 'GET').done(function (data) {
            self.detail(data);
            $.each(data.SubCustomers, function () {

                self.contacts.push(this);

            })
            console.log(self.contacts());
        });
    }

    self.newMainCustomer = {
        CustomerName: ko.observable(),
        Description: ko.observable(),
        Address: ko.observable(),
        Lat: ko.observable(),
        Long: ko.observable(),
        ContactPersonName: ko.observable(),
        ContactPersonNumber: ko.observable()
    }

    self.addMainCustomer = function (formElement) {
        var customerObj = {

            CustomerName: self.newMainCustomer.CustomerName(),
            Description: self.newMainCustomer.Description(),
            Address: self.newMainCustomer.Address(),
            Lat: self.newMainCustomer.Lat(),
            Long: self.newMainCustomer.Long(),
            ContactPersonName: self.newMainCustomer.ContactPersonName(),
            ContactPersonNumber: self.newMainCustomer.ContactPersonNumber()

        };

        ajaxHelper(customersLink, 'POST', customerObj).done(function (item) {
            self.customers.push(item);
        });
    }



    self.newContact = {
        MainCustomerId: ko.observable(),
        SubCustomerName: ko.observable(),
        SubCustomerEmail: ko.observable(),
        SubCustomerContactNumber : ko.observable(),
       
    }


    

    var contactsLink = '/api/Sub_Customer/';
    self.addContact = function (formElement) {
        var contactObj = {

            Main_CustomerID: $('#SelectedCustomerID').text(),
            SubCustomerName: self.newContact.SubCustomerName(),
            SubCustomerEmail: self.newContact.SubCustomerEmail(),
            SubCustomerContactNumber: self.newContact.SubCustomerContactNumber(),
            
        };

        ajaxHelper(contactsLink, 'POST', contactObj).done(function (item) {
            self.contacts.push(item);
        });
    }

    self.deleteContact = function (item) {

        var delItem = item;

        ajaxHelper(contactsLink + item.Id, 'DELETE').done(function () {

            $.each(self.contacts(), function (index) {
               

                if (this.Id == delItem.Id) {
                   
                    self.contacts.splice(index, 1);
                }
            })
            
        });
    }
};

ko.applyBindings(new ViewModel());



});