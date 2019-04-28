var API_PREFIX           = 'api/employee';
var API_EMP_BY_ID        = '?id=';
var API_EMP_BY_NAME      = '?name=';
var API_EMP_SAVE         = '?emp=';
var API_EMP_DELETE_BY_ID = '?id=';

function getEmployees() {
    $.getJSON(API_PREFIX, (data) => 
        $(".emp_all").html(buildTable(data))
    );
}

function getEmployeeById() {
    $.getJSON(API_PREFIX + API_EMP_BY_ID + $("#emp_id").val(), (data) => 
        $(".emp_by_id").html(buildTable([data]))
    ).fail(() => 
        alert("User doesn't exist")
    );
}

function getEmployeeByName() {
    var url = API_PREFIX + API_EMP_BY_NAME + $("#emp_name").val();
    $.getJSON(url, (data) => 
        $(".emp_by_name").html(buildTable(data))
    ).fail(() => 
        alert("User doesn't exist")
    );
}

function saveEmployee() {
    $.ajax(API_PREFIX + API_EMP_SAVE, {
        data: JSON.stringify({
            FirstName: $("#emp_first_name").val(),
            LastName: $("#emp_last_name").val(),
            Department: $("#emp_department").val()
        }),
        contentType: 'application/json',
        type: 'POST'
    }).fail(() =>
        alert("Invalid params")
    );
}

function changeEmployee() {
    $.ajax(API_PREFIX + API_EMP_SAVE, {
        data: JSON.stringify({
            Id: $("#emp_id_c").val(),
            FirstName: $("#emp_first_name_c").val(),
            LastName: $("#emp_last_name_c").val(),
            Department: $("#emp_department_c").val()
        }),
        contentType: 'application/json',
        type: 'PUT'
    }).fail(() =>
        alert("User doesn't exist or invalid input")
    );
}

function deleteEmployee() {
    $.ajax(API_PREFIX + API_EMP_DELETE_BY_ID + $("#emp_delete_id").val(), {
        type: 'DELETE'
    }).fail(() =>
        alert("User doesn't exist")
    );
}

function buildTable(object) {
    html = "<table class='table'><thead> <th>ID</th> <th>First Name</th> <th>Last Name</th> <th>Department</th> </thead>";
    $.each(object, function (key, item) {
        html += "<tr><td>" + item.Id + '</td><td>' + item.FirstName + '</td><td>' + item.LastName + '</td><td>' + item.Department + "</td></tr>";
    });
    return html + "</table>";
}
