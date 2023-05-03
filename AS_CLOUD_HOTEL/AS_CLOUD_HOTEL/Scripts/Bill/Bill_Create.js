var BillApp = angular.module("BillApp", ['ui.bootstrap']);

BillApp.controller("ApiBillController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;


    $scope.toggleEdit = function () {
        this.testitem.editMode = !this.testitem.editMode;
    };



    $scope.toggleEdit_Cancel = function () {
        this.testitem.editMode = !this.testitem.editMode;

        //Grid view load
        var companyid = $('#txtcompid').val();
        var transMonthYear = $('#hiddentxt_TransMonthYear').val();
        var transNo = $('#transNO').val();

        $http.get('/api/ApiBill/GetItemList/', {
            params: {
                cid: companyid,
                myear: transMonthYear,
                memoNO: transNo
            }
        }).success(function (data) {
            if (data[0].count == 1) {
                $scope.BillDetailsData = null;
            } else {
                $scope.BillDetailsData = data;
            }
            $scope.loading = false;
        });
    };



    // Add child Data from registration table
    $scope.submit = function (event) {
        $scope.loading = false;
        event.preventDefault();
        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#transactionDate').val("");
            $('#transNO').val("");
            $('#txt_ROOMNO').val("");
            $('#txt_REGNID').val("");
            alert("Permission Denied!!");
            window.location.reload(true);
        } else {
            var COMPID = $('#txtcompid').val();
            var INSUSERID = $('#txtInsertUserid').val();
            var INSLTUDE = $('#latlon').val();

            var TRANSMY = $('#hiddentxt_TransMonthYear').val();
            var TRANSDT = $('#transactionDate').val();
            var TRANSNO = $('#transNO').val();
            var ROOMNO = $('#txt_ROOMNO').val();
            var REGNID = $('#txt_REGNID').val();
           

            if (TRANSMY != "" && TRANSDT != 0 && TRANSNO != "" && ROOMNO != "" && REGNID != "") {
                $http.get('/api/ApiBill/AddChildData/', {
                    params: {
                        Compid: COMPID,
                        insertUserID: INSUSERID,
                        insltude: INSLTUDE,
                        transMonthyear: TRANSMY,
                        transDate: TRANSDT,
                        transno: TRANSNO,
                        roomNo: ROOMNO,
                        registrationID: REGNID
                      
                    }
                }).success(function (data) {

                    if (data[0].TRANSNO != 0) {
                        var memoNO = data[0].TRANSNO;
                        $('#transNO').val(memoNO);

                        var transDate = data[0].TRANSDT;
                        $('#transactionDate').val(transDate);

                        var advanceAmount = data[0].ADVAMT;
                        $('#txtMst_ADVAMT').val(advanceAmount);
                        
                        //alert("Create Successfully !!");
                        //$scope.MediMasterData.push({ ID: data.ID, MCATID: data.MCATID, MCATNM: data.MCATNM });
                    } else {
                        alert("Please create again!");
                        window.location.reload(true);
                    }

                    //Grid view load 
                    var companyid = $('#txtcompid').val();
                    var transMonthYear = $('#hiddentxt_TransMonthYear').val();
                    var transNo = $('#transNO').val();

                    $http.get('/api/ApiBill/GetItemList/', {
                        params: {
                            cid: companyid,
                            myear: transMonthYear,
                            memoNO: transNo
                        }
                    }).success(function (data) {
                        if (data[0].count == 1) {
                            $scope.BillDetailsData = null;
                        } else {
                            $scope.BillDetailsData = data;
                        }
                        $scope.loading = false;
                    });

                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
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
            $('#transactionDate').val("");
            $('#transNO').val("");
            $('#txt_ROOMNO').val("");
            $('#txt_REGNID').val("");
            //alert("Permission Denied!!");
            swal("Here's a message!", "Permission Denied!");
        }
        else {
            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();
            this.newChild.TRANSMY = $('#hiddentxt_TransMonthYear').val();

            this.newChild.TRANSDT = $('#transactionDate').val();
            this.newChild.TRANSNO = $('#transNO').val();
            this.newChild.ROOMNO = $('#txt_ROOMNO').val();
            this.newChild.REGNID = $('#txt_REGNID').val();

            this.newChild.BILLID = $('#billid').val();
            this.newChild.AMOUNT = $('#amount').val();
            this.newChild.REMARKS = $('#remarks').val();


            if (this.newChild.TRANSMY != "" && this.newChild.TRANSDT != 0 && this.newChild.TRANSNO != "" && this.newChild.ROOMNO != "" && this.newChild.REGNID != "" && this.newChild.BILLID != "" && this.newChild.AMOUNT != "") {
                $http.post('/api/ApiBill/Addrow', this.newChild).success(function (data, status, headers, config) {
                    
                    //Disabled required field when select insert button.
                    //$("#transactionType").prop("disabled", true);
                    //$("#transactionDate").prop("disabled", true);
                    //$("#patientType").prop("disabled", true);
                    //$("#patientYearId").prop("disabled", true);


                    //Grid view load 
                    var companyid = $('#txtcompid').val();
                    var transMonthYear = $('#hiddentxt_TransMonthYear').val();
                    var transNo = $('#transNO').val();

                    $http.get('/api/ApiBill/GetItemList/', {
                        params: {
                            cid: companyid,
                            myear: transMonthYear,
                            memoNO: transNo
                        }
                    }).success(function (data) {
                        if (data[0].count == 1) {
                            $scope.BillDetailsData = null;
                        } else {
                            $scope.BillDetailsData = data;
                        }
                        $scope.loading = false;
                    });


                    if (data.BILLID != 0) {
                        $('#remarks').val("");
                        $('#amount').val("0");
                        //alert("Create Successfully !!");
                        //swal("Create Successfully!", "You clicked the button!", "success");
                        //$scope.BillDetailsData.push({ ID: data.ID, MCATID: data.MCATID, MEDIID: data.MEDIID, MEDINM: data.MEDINM, PHARMAID: data.PHARMAID, GHEADID: data.GHEADID });
                    } else {
                        $('#remarks').val("");
                        $('#amount').val("0");
                        //alert("Duplicate name will not create!");
                        swal("warning!", "Duplicate name will not create!", "error");
                    }

                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                    $scope.loading = false;
                });

            }
            else if (this.newChild.AMOUNT == 0 || this.newChild.AMOUNT == "") {
                //alert("Please select valid item name first !!");
                swal("warning!", "Please input amount field !", "error");
            }
            else {
                //alert("Please input required field !!");
                swal("warning!", "Please input required field !", "error");
            }
        }
    };





    //Update to grid level data
    $scope.update = function () {
        $scope.loading = true;
        var frien = this.testitem;

        this.testitem.COMPID = $('#txtcompid').val();
        this.testitem.INSUSERID = $('#txtInsertUserid').val();
        this.testitem.INSLTUDE = $('#latlon').val();
        this.testitem.TRANSMY = $('#hiddentxt_TransMonthYear').val();        

        this.testitem.TRANSDT = $('#transactionDate').val();
        this.testitem.TRANSNO = $('#transNO').val();
        this.testitem.ROOMNO = $('#txt_ROOMNO').val();
        this.testitem.REGNID = $('#txt_REGNID').val();
        
        $http.post('/api/ApiBill/UpdateData', this.testitem).success(function (data) {
            if (data.BILLID != 0) {
                //alert("Saved Successfully!!");
                //swal("Update Successfully!", "You clicked the button!", "success");
                //swal({
                //    title: "Update Successfully!",
                //    imageUrl: "/Content/SweetAlert/images/thumbs-up.jpg"
                //});
            } else {
                //alert("Duplicate data will not create!");
                swal("warning!", "Duplicate data will not create!", "error");
            }

            frien.editMode = false;

            //Grid view load 
            var companyid = $('#txtcompid').val();
            var transMonthYear = $('#hiddentxt_TransMonthYear').val();
            var transNo = $('#transNO').val();

            $http.get('/api/ApiBill/GetItemList/', {
                params: {
                    cid: companyid,
                    myear: transMonthYear,
                    memoNO: transNo
                }
            }).success(function (data) {
                if (data[0].count == 1) {
                    $scope.BillDetailsData = null;
                } else {
                    $scope.BillDetailsData = data;
                }
            });
            $scope.loading = false;

        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Friend! " + data;
            $scope.loading = false;

        });
    };






    //Delete grid level data.
    $scope.deleteItem = function () {
        $scope.loading = true;
        var id = this.testitem.ID;

        this.testitem.TRANSMY = $('#hiddentxt_TransMonthYear').val();
        this.testitem.TRANSDT = $('#transactionDate').val();
        this.testitem.TRANSNO = $('#transNO').val();
        this.testitem.ROOMNO = $('#txt_ROOMNO').val();
        this.testitem.REGNID = $('#txt_REGNID').val();
        
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
                swal("Cancelled", "Your imaginary file is safe :)", "error");
            }
        });
    };


    function deleteGridLevelData(model) {
        $http.post('/api/ApiBill/DeleteData', model).success(function (data) {

            //Grid view load 
            var companyid = $('#txtcompid').val();
            var transMonthYear = $('#hiddentxt_TransMonthYear').val();
            var transNo = $('#transNO').val();

            $http.get('/api/ApiBill/GetItemList/', {
                params: {
                    cid: companyid,
                    myear: transMonthYear,
                    memoNO: transNo
                }
            }).success(function (data) {
                if (data[0].count == 1) {
                    $scope.BillDetailsData = null;
                } else {
                    $scope.BillDetailsData = data;
                }
                $scope.loading = false;
            });

        }).error(function (data) {
            $scope.error = "An Error has occured while delete posts! " + data;
            $scope.loading = false;
        });
    }






    $scope.GetSummOfAmount = function (BillDetailsData) {
        var summ = 0;
        for (var i in BillDetailsData) {
            summ = summ + Number(BillDetailsData[i].AMOUNT);
        }

        var gridTotalAmount = document.getElementById('gridTotalAmount').innerHTML;
        $("#txtMst_TotalAmount").val(gridTotalAmount);

        //document.getElementById('txtMst_VatAmount').value = (document.getElementById('txtMst_TotalAmount').value * (document.getElementById('txtMst_VatRT').value / 100)).toFixed(2);
        //document.getElementById('txtMst_NetAmount').value = (parseFloat(document.getElementById('txtMst_TotalAmount').value) + parseFloat(document.getElementById('txtMst_VatAmount').value) - parseFloat(document.getElementById('txtMst_DiscAmt').value)).toFixed(2);

        return summ;
    };
    
});