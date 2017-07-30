$(document).ready(function () {



var ViewModel = function () {
    var self = this;
    self.customers = ko.observableArray();
    self.error = ko.observable();
    self.contacts = ko.observableArray();
    var customersLink = "/api/Main_Customer/";

    function ajaxHelper(uri, method, data) {
        self.error(""); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: "json",
            contentType: "application/json",
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    self.getAllCustomers = function() {
        ajaxHelper(customersLink, "GET").done(function (data) {
            self.customers(data);
            

        });
    }

      

    self.detail = ko.observable();

    self.getMainCustomer = function (item) {

        self.contacts.removeAll();
                        
        ajaxHelper(customersLink + item.Id, "GET").done(function (data) {
            
            self.detail(data);
            
            $.each(data.SubCustomers, function () {

                self.contacts.push(this);

            });
            
        });

        $("#CustomerList").attr("hidden", "hidden");
        $("#detailsPanel").removeAttr("hidden");
        $("#detailsPanel").addClass("currentPanel");
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
        console.log("amc clicked");
        var customerObj = {
            
            CustomerName: self.newMainCustomer.CustomerName(),
            Description: self.newMainCustomer.Description(),
            Address: self.newMainCustomer.Address(),
            Lat: self.newMainCustomer.Lat(),
            Long: self.newMainCustomer.Long(),
            ContactPersonName: self.newMainCustomer.ContactPersonName(),
            ContactPersonNumber: self.newMainCustomer.ContactPersonNumber()

        };

        ajaxHelper(customersLink, "POST", customerObj).done(function (item) {
            self.customers.push(item);
            var inputs = $('input[type = text]');

            
            $('.modal').modal('show');
           

            for (var i = 0; i < inputs.length; i++) {
                inputs[i].value = '';
            }
        });
    }
  


    self.newContact = {
        MainCustomerId: ko.observable(),
        SubCustomerName: ko.observable(),
        SubCustomerEmail: ko.observable(),
        SubCustomerContactNumber: ko.observable()

    };


    

    var contactsLink = "/api/Sub_Customer/";
    self.addContact = function (formElement) {
        var contactObj = {

            Main_CustomerID: $("#SelectedCustomerID").text(),
            SubCustomerName: self.newContact.SubCustomerName(),
            SubCustomerEmail: self.newContact.SubCustomerEmail(),
            SubCustomerContactNumber: self.newContact.SubCustomerContactNumber()
            
        };

        ajaxHelper(contactsLink, "POST", contactObj).done(function (item) {
            self.contacts.push(item);
            var inputs = $('input[type = text]');


            $('.modal').modal('show');


            for (var i = 0; i < inputs.length; i++) {
                inputs[i].value = '';
            }
        });
    }

    self.deleteContact = function (item) {

        var delItem = item;

        ajaxHelper(contactsLink + item.Id, "DELETE").done(function () {

            $.each(self.contacts(), function (index) {
               

                if (this.Id == delItem.Id) {
                   
                    self.contacts.splice(index, 1);
                }
            })
            
        });
    }
};


    var vm = new ViewModel();

    ko.applyBindings(vm);

    $("#EditCustomersBtn").on("click", function () {

        vm.getAllCustomers();

        $("#MainMenuPanel").attr("hidden", "hidden");
        $("#CustomerList").removeAttr("hidden");
        $("#CustomerList").addClass("currentPanel");
    });

    $("#AddCustomerBtn").on("click", function () {

        $("#MainMenuPanel").attr("hidden", "hidden");
        $("#AddCustomerPanel").removeAttr("hidden");
        $("#AddCustomerPanel").addClass("currentPanel");
    });



    $("#HomeBtn").on("click", function () {
       
        $(".currentPanel").attr("hidden", "hidden");

        $("#MainMenuPanel").removeAttr("hidden");
    });

   

    $(document).on("click", "#AddContactBtn", function () {

        $('#viewContactsPanel').attr('hidden', 'hidden');
        $('#addContactPanel').removeAttr('hidden');

    });

    $(document).on("click", "#addContactSubBtn", function () {

        $('#addContactPanel').attr('hidden', 'hidden');
        $('#viewContactsPanel').removeAttr('hidden');

    });

    $(document).on("click", "#submitContactBtn", function () {

        $('#addContactPanel').attr('hidden', 'hidden');
        $('#viewContactsPanel').removeAttr('hidden');

    });


        $(document).on('keyup', 'input[type=text]', function (event) {

      
        var input = $(this);
        setTimeout(function () {
            var val = input.val();
            if (val != "") {
                 var label = input.parent().find("label");
                $(label).velocity({ translateX: "5px", translateY: "-15px", scale: 0.5 }, 400);

            }
            else
                $(label).velocity({ translateX: "-5px", translateY: "15px", scale: 1 }, 400);
        }, 1)

    })

     
       
        $('#AddCustomerBtn').on({
            mouseenter: function () {

                $('#AddCustomerBtn').velocity({ scale: 1.6 }, 400);
                $('#addcustext').removeAttr('hidden').velocity('transition.fadeIn');
            },
            mouseleave: function () {
                $('#AddCustomerBtn').velocity({ scale: 1 }, 400);
                $('#addcustext').attr('hidden','hidden').velocity('transition.fadeOut');
            }
        });

        $('#EditCustomersBtn').on({
            mouseenter: function () {

                $('#EditCustomersBtn').velocity({ scale: 1.6 }, 400);
                $('#editcustext').removeAttr('hidden').velocity('transition.fadeIn');
            },
            mouseleave: function () {
                $('#EditCustomersBtn').velocity({ scale: 1 }, 400);
                $('#editcustext').attr('hidden', 'hidden').velocity('transition.fadeOut');
            }
        });
});


