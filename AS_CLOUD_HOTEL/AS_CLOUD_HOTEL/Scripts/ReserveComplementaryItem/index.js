var ReserveComplementaryItemApp = angular.module("ReserveComplementaryItemApp", ['ui.bootstrap']);

ReserveComplementaryItemApp.controller("ApiReserveComplementaryItemController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;


    $scope.search = function (event) {

        $scope.loading = true;
        event.preventDefault();

        var compid = $('#txtcompid').val();
        var reserveid = $('#txt_RESVID option:selected').val();

        $http.get('/api/ApiReserveComplementaryItem/GetData/', {
            params: {
                companyID: compid,
                reserveID: reserveid,
            }
        }).success(function (data) {
            if (data[0].count == 1) {
                $scope.ComplementaryItemData = null;
            } else {
                $scope.ComplementaryItemData = data;
            }
            $scope.loading = false;
        });

    };




    $scope.toggleEdit = function () {
        this.testitem.editMode = !this.testitem.editMode;
    };



    $scope.toggleEdit_Cancel = function () {
        this.testitem.editMode = !this.testitem.editMode;

        //Grid view load 
        var compid = $('#txtcompid').val();
        var reserveid = $('#txt_RESVID option:selected').val();

        $http.get('/api/ApiReserveComplementaryItem/GetData/', {
            params: {
                companyID: compid,
                reserveID: reserveid,
            }
        }).success(function (data) {
            $scope.ComplementaryItemData = data;
            $scope.loading = false;
        });
    };




    //Add grid level data
    $scope.addrow = function (event) {
        $scope.loading = false;
        event.preventDefault();

        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#CItemNameid').val("-SELECT-");
            alert("Permission Denied!!");
        }
        else {

            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();

            this.newChild.RESVID = $('#txt_RESVID option:selected').val();
            this.newChild.CITEMID = $('#CItemNameid option:selected').val();

            if (this.newChild.RESVID != "" && this.newChild.CITEMID != "" && this.newChild.RESVID != 0 && this.newChild.CITEMID != 0) {
                $http.post('/api/ApiReserveComplementaryItem/AddData', this.newChild).success(function (data, status, headers, config) {

                    //Grid view load 
                    var compid = $('#txtcompid').val();
                    var reserveid = $('#txt_RESVID option:selected').val();

                    $http.get('/api/ApiReserveComplementaryItem/GetData/', {
                        params: {
                            companyID: compid,
                            reserveID: reserveid,
                        }
                    }).success(function (data) {
                        $scope.ComplementaryItemData = data;
                        $scope.loading = false;
                    });


                    var changedText = $("#txt_RESVID").val();
                    var reservDate = $("#txt_RESVDT").val();
                    var compid = $('#txtcompid').val();
                    $("#CItemNameid").val(" ");
                    $.ajax
                    ({
                        url: '/ReserveComplementaryItem/ComplementaryItemLoad',
                        type: 'post',
                        dataType: "json",
                        data: { reserveID: changedText, theDate: reservDate, companyid: compid },
                        success: function (data) {
                            $("#CItemNameid").empty();
                            $("#CItemNameid").append('<option value="'
                                + "Select" + '">'
                                + "Select" + '</option>');


                            $.each(data, function (i, memo) {

                                $("#CItemNameid").append('<option value="'
                                    + memo.Value + '">'
                                    + memo.Text + '</option>');

                            });
                        }
                    });


                    if (data.CITEMID != 0) {
                        $('#CItemNameid').val("-SELECT-");
                        alert("Create Successfully !!");
                        //$scope.ComplementaryItemData.push({ ID: data.ID, MCATID: data.MCATID, MEDIID: data.MEDIID, MEDINM: data.MEDINM, PHARMAID: data.PHARMAID, GHEADID: data.GHEADID });
                    } else {
                        $('#CItemNameid').val("-SELECT-");
                        alert("Duplicate name will not create!");
                    }

                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                    $scope.loading = false;
                });

            }
            else {
                $('#CItemNameid').val("-SELECT-");
                alert("Please Select grid level data !!");
            }

        }
    };




    ////Update to grid level data (save a record after edit)
    //$scope.update = function () {
    //    $scope.loading = true;
    //    var frien = this.testitem;

    //    this.testitem.COMPID = $('#txtcompid').val();
    //    this.testitem.INSUSERID = $('#txtInsertUserid').val();
    //    this.testitem.INSLTUDE = $('#latlon').val();

    //    var Update = $('#txt_Updateid').val();

    //    if (Update == "I") {
    //        alert("Permission Denied!!");
    //        frien.editMode = false;

    //        //Grid view load 
    //        var compid = $('#txtcompid').val();
    //        var reserveid = $('#txt_RESVID option:selected').val();

    //        $http.get('/api/ApiReserveComplementaryItem/GetData/', {
    //            params: {
    //                companyID: compid,
    //                reserveID: reserveid,
    //            }
    //        }).success(function (data) {
    //            $scope.ComplementaryItemData = data;
    //        });

    //        $scope.loading = false;
    //    }
    //    else {
    //        $http.post('/api/ApiReserveComplementaryItem/UpdateData', this.testitem).success(function (data) {
    //            alert("Saved Successfully!!");
    //            frien.editMode = false;

    //            //Grid view load 
    //            var compid = $('#txtcompid').val();
    //            var reserveid = $('#txt_RESVID option:selected').val();

    //            $http.get('/api/ApiReserveComplementaryItem/GetData/', {
    //                params: {
    //                    companyID: compid,
    //                    reserveID: reserveid,
    //                }
    //            }).success(function (data) {
    //                $scope.ComplementaryItemData = data;
    //            });

    //            $scope.loading = false;

    //        }).error(function (data) {
    //            $scope.error = "An Error has occured while Saving Friend! " + data;
    //            $scope.loading = false;

    //        });
    //    }
    //};





    //Delete grid level data.
    $scope.deleteItem = function () {
        $scope.loading = true;
        var id = this.testitem.ID;

        var Delete = $('#txt_Deleteid').val();
        if (Delete == "I") {
            alert("Permission Denied!!");
        }
        else {

            this.testitem.COMPID = $('#txtcompid').val();
            this.testitem.INSUSERID = $('#txtInsertUserid').val();
            this.testitem.INSLTUDE = $('#latlon').val();

            $http.post('/api/ApiReserveComplementaryItem/DeleteData/', this.testitem).success(function (data) {

                var changedText = $("#txt_RESVID").val();
                var reservDate = $("#txt_RESVDT").val();
                var compid = $('#txtcompid').val();
                $("#CItemNameid").val(" ");
                $.ajax
                ({
                    url: '/ReserveComplementaryItem/ComplementaryItemLoad',
                    type: 'post',
                    dataType: "json",
                    data: { reserveID: changedText, theDate: reservDate, companyid: compid },
                    success: function (data) {
                        $("#CItemNameid").empty();
                        $("#CItemNameid").append('<option value="'
                            + "Select" + '">'
                            + "Select" + '</option>');


                        $.each(data, function (i, memo) {

                            $("#CItemNameid").append('<option value="'
                                + memo.Value + '">'
                                + memo.Text + '</option>');

                        });
                    }
                });

                $.each($scope.ComplementaryItemData, function (i) {
                    if ($scope.ComplementaryItemData[i].ID === id) {
                        $scope.ComplementaryItemData.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
                alert("Delete Successfully!!");

            }).error(function (data) {
                $scope.error = "An Error has occured while delete posts! " + data;
                $scope.loading = false;
            });
        }
    };



});