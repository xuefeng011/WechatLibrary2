(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            addWindow: Ext.getCmp('addWindow'),
            modifyWindow: Ext.getCmp('modifyWindow'),
            txtNewTextMatch: Ext.getCmp('txtNewTextMatch'),
            storeTextMatches: Ext.StoreManager.get('storeTextMatches'),
            cmbResponseType: Ext.getCmp('cmbResponseType'),
            cmbResponseTypeSelected: function (parameters) {
                var selectedValue = window.viewModel.cmbResponseType.value;
                if (selectedValue == '文本') {
                    
                } else if (selectedValue == '图片') {
                } else if (selectedValue == '图文') {
                }
            },
            addNewWehcatTextRequestMatchCommand: function (parameters) {
                window.viewModel.txtNewTextMatch.setRawValue('');
                window.viewModel.addWindow.show();
            },
            saveNewWechatTextRequestMatchCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Service/TextRequestMatchService/Add.ashx',
                    method: 'POST',
                    params: {
                        Content: window.viewModel.txtNewTextMatch.getRawValue()
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.storeTextMatches.load();
                                window.viewModel.addWindow.close();
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'add failed!');
                    }
                });
            },
            textMatchesCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                    Ext.Ajax.request({
                        url: '/Service/TextRequestMatchService/GetById.ashx',
                        method: 'POST',
                        params: { Id: data.Id },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                // Get the text match data from json object.
                                var data = responseObj.data;

                                // Set each control value;

                                // Show the setting window.
                                window.viewModel.modifyWindow.show();
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'load information fail!');
                        }
                    });
                } else if (commandName == "delete") {
                    Ext.Msg.confirm('Warning', 'make sure to delete this match?', function (btn) {
                        if (btn == 'yes') {
                            Ext.Ajax.request({
                                url: '/Service/TextRequestMatchService/Delete.ashx',
                                method: 'POST',
                                params: {
                                    Id: data.Id
                                },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info, function () {
                                            // Refresh the grid panel.
                                            window.viewModel.storeTextMatches.load();
                                        });
                                    } else {
                                        Ext.Msg.alert('Error', responseObj.info);
                                    }
                                },
                                failure: function (response, options) {
                                    Ext.Msg.alert('Error', 'delete fail!');
                                }
                            });
                        }
                    });
                }
            }
        };
    });
}());
