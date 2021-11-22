var savecookdays = [{ "id": 7, "text": "保存7天", "selected": true }, { "id": 30, "text": "保存30天" }, { "id": 365, "text": "保存永久" }, { "id": 1, "text": "不保存" }];

$(function () {
    //checkSession();
    inintPanel();
});


//初始化登录面板
function inintPanel() {
    $("<div/>").dialog({
        title: 'login', modal: false,
        width: 300, height: 250,
        cache: false, closed: false,
        href: '../common/html/loginForm.html',
        buttons: [
            {
                text: '登录',
                handler: login
            }
        ],
        onLoad: function () {
            $("#txt_save").combobox({
                data: savecookdays,
                valueField: 'id',
                textField: 'text',
                editable: false,
                panelHeight: 'auto'
            });
            $('#imgValidateCode').click(function () {
                $(this).attr('src', "../ashx/ValidateCode.ashx?t=4&n=" + Math.random());
            });

        }
    });
    $(this).keydown(function (event) {
        if (event.keyCode == 13) {
            event.returnValue = false;
            event.cancel = true;
            return login();
        }
    });
}

//登录按钮事件
function login() {
    $("#loginForm").form("submit", {
        url: "../ashx/LoginHandler.ashx",
        onSubmit: function () {
            var isValid = $("#loginForm").form('validate');
            if (isValid) {
                $.messager.show({
                    title: '登录中...',
                    timeout: 500,
                showType:'slide'
            });
            }
            return isValid;
        },
        success: function (data) {
            data = JSON.parse(data);
            if (!data.success) {
                $('#imgValidateCode').click();
                $.messager.alert('错误', data.message, 'error');
            }
            else {
                location.href = "../index.html";
            }
        }
    });
}