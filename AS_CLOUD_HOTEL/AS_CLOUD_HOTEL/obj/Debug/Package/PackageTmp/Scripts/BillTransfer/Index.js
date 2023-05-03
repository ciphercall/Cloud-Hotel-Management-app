var BillTransferApp = angular.module("BillTransferApp", ['ui.bootstrap']);

BillTransferApp.controller("ApiBillTransferController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;


    $scope.toggleEdit = function () {
        this.testitem.editMode = !this.testitem.editMode;
    };



    //$scope.toggleEdit_Cancel = function () {
    //    this.testitem.editMode = !this.testitem.editMode;

    //    //Grid view load
    //    var companyid = $('#txtcompid').val();
    //    var roomNo = $('#txt_ROOMNO_Parent').val();
    //    var registrationID = $('#txt_REGNID_Parent').val();

    //    $http.get('/api/ApiBillTransfer/GetItemList/', {
    //        params: {
    //            cid: companyid,
    //            room: roomNo,
    //            regid: registrationID
    //        }
    //    }).success(function (data) {
    //        if (data[0].count == 1) {
    //            $scope.RegistrationData = null;
    //        } else {
    //            $scope.RegistrationData = data;
    //        }
    //        $scope.loading = false;
    //    });
    //};



    // Add child Data from registration table
    $scope.submit = function (event) {
        $scope.loading = false;
        event.preventDefault();
        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#txt_GUESTNM_Parent').val("");
            $('#txt_ROOMNO_Parent').val("");
            $('#txt_REGNID_Parent').val("");
            alert("Permission Denied!!");
            window.location.reload(true);
        } else {
            var ROOMNO = $('#txt_ROOMNO_Parent').val();
            var REGNID = $('#txt_REGNID_Parent').val();
            
            if (ROOMNO != "" && REGNID != "" && REGNID!=0) {

                //Grid view load
                var companyid = $('#txtcompid').val();
                var roomNo = $('#txt_ROOMNO_Parent').val();
                var registrationID = $('#txt_REGNID_Parent').val();

                $http.get('/api/ApiBillTransfer/GetItemList/', {
                    params: {
                        cid: companyid,
                        room: roomNo,
                        regid: registrationID
                    }
                }).success(function (data) {
                    if (data[0].count == 1) {
                        $scope.RegistrationData = null;
                    } else {
                        $scope.RegistrationData = data;
                    }
                    $scope.loading = false;
                });



            }
            else {
                alert("Please input required field !!");
            }
        }
    };




    //Add grid level data
    $scope.addrow = function (event) {
        $scope.loading = false;
        event.preventDefault();

        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#txt_GUESTNM_Parent').val("");
            $('#txt_ROOMNO_Parent').val("");
            $('#txt_REGNID_Parent').val("");
            //alert("Permission Denied!!");
            swal("Here's a message!", "Permission Denied!");
        }
        else {
            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();
            
            this.newChild.ROOMNO_Parent = $('#txt_ROOMNO_Parent').val();
            this.newChild.REGNID_Parent = $('#txt_REGNID_Parent').val();

            this.newChild.Transaction_Date = $('#grid_TransactionDate').val();
            this.newChild.ROOMNO_Child = $('#grid_ROOMNO_Child').val();
            this.newChild.REGNID__Child = $('#grid_registrationID').val();
            this.newChild.GUESTNM_Child = $('#grid_GUESTNM_Child').val();
            this.newChild.Remarks = $('#grid_remarks').val();


            if (this.newChild.ROOMNO_Parent != "" && this.newChild.ROOMNO_Parent != 0 && this.newChild.REGNID_Parent != "" && this.newChild.REGNID_Parent != 0 && this.newChild.TransactionDate != "" && this.newChild.ROOMNO_Child != "" && this.newChild.ROOMNO_Child != 0 && this.newChild.ID != 0 && this.newChild.ID != "") {
                $http.post('/api/ApiBillTransfer/Addrow', this.newChild).success(function (data, status, headers, config) {

                    //Grid view load
                    var companyid = $('#txtcompid').val();
                    var roomNo = $('#txt_ROOMNO_Parent').val();
                    var registrationID = $('#txt_REGNID_Parent').val();

                    $http.get('/api/ApiBillTransfer/GetItemList/', {
                        params: {
                            cid: companyid,
                            room: roomNo,
                            regid: registrationID
                        }
                    }).success(function (data) {
                        if (data[0].count == 1) {
                            $scope.RegistrationData = null;
                        } else {
                            $scope.RegistrationData = data;
                        }
                        $scope.loading = false;
                    });



                    if (data.REGNID__Child != 0) {
                        $('#grid_registrationID').val("");
                        $('#grid_GUESTNM_Child').val("");
                        $('#grid_remarks').val("");
                    } else {
                        $('#grid_registrationID').val("");
                        $('#grid_GUESTNM_Child').val("");
                        $('#grid_remarks').val("");
                        //alert("Duplicate name will not create!");
                        swal("warning!", "Duplicate name will not create!", "error");
                    }

                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                    $scope.loading = false;
                });

            }
            else {
                //alert("Please input required field !!");
                swal("warning!", "Please input required field !", "error");
            }
        }
    };





    //Delete grid level data.
    $scope.deleteItem = function () {
        $scope.loading = true;
        var id = this.testitem.ID;
      
        this.testitem.ROOMNO_Parent = $('#txt_ROOMNO_Parent').val();
        this.testitem.REGNID_Parent = $('#txt_REGNID_Parent').val();

        this.testitem.ROOMNO_Child = $('#gridRoomNoChild').val();
        this.testitem.REGNID__Child = $('#gridRegnidChild').val();
        this.testitem.Remarks = $('#gridRemarksId').val();
        
        this.testitem.COMPID = $('#txtcompid').val();
        this.testitem.INSUSERID = $('#txtInsertUserid').val();
        this.testitem.INSLTUDE = $('#latlon').val();

        //Sweet Alart Design box
        var model = this.testitem;
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel plz!",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm) {
                deleteGridLevelData(model);
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            } else {
                //Grid view load
                var companyid = $('#txtcompid').val();
                var roomNo = $('#txt_ROOMNO_Parent').val();
                var registrationID = $('#txt_REGNID_Parent').val();

                $http.get('/api/ApiBillTransfer/GetItemList/', {
                    params: {
                        cid: companyid,
                        room: roomNo,
                        regid: registrationID
                    }
                }).success(function (data) {
                    if (data[0].count == 1) {
                        $scope.RegistrationData = null;
                    } else {
                        $scope.RegistrationData = data;
                    }
                    $scope.loading = false;
                });
                swal("Cancelled", "Your imaginary file is safe :)", "error");
            }
        });
    };


    function deleteGridLevelData(model) {
        $http.post('/api/ApiBillTransfer/UpdateData', model).success(function (data) {

            //Grid view load
            var companyid = $('#txtcompid').val();
            var roomNo = $('#txt_ROOMNO_Parent').val();
            var registrationID = $('#txt_REGNID_Parent').val();

            $http.get('/api/ApiBillTransfer/GetItemList/', {
                params: {
                    cid: companyid,
                    room: roomNo,
                    regid: registrationID
                }
            }).success(function (data) {
                if (data[0].count == 1) {
                    $scope.RegistrationData = null;
                } else {
                    $scope.RegistrationData = data;
                }
                $scope.loading = false;
            });

        }).error(function (data) {
            $scope.error = "An Error has occured while delete posts! " + data;
            $scope.loading = false;
        });
    }

});