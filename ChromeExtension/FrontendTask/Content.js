
var currentPage = 1;
var totalPages;
function getPage(page) {
const apiCall = "https://reqres.in/api/users?page="+page;

fetch(apiCall).then(function(data)
{

  data.json().then(function(info){

     if(page <= info.total_pages)
     {
       totalPages = info.total_pages;
      $("#numOfPages").text("Pages: "+info.total_pages);
      $("#userInfoTable tbody").empty();
      
      for (let i = 0; i < info.per_page; i++) {
    
        $("#userInfoTable tbody").append(
            "<tr>" + 
            "<td>"+info.data[i].email+"</td>" +
            "<td>"+info.data[i].first_name+"</td>" +
            "<td>"+info.data[i].last_name+"</td>" +
            "<td> <img src='"+info.data[i].avatar+"' alt='Avatar' class= 'avatar' height=50 width=50></td>"+
            "</tr>");
      
        }

        currentPage = page;
     }
   
  
  });
 
 
});

}

$( document ).ready(function() {

  var info = getPage(currentPage);
 
});


$("#nextButton").click(function(){

  getPage(currentPage+1);

});    

$("#previousButton").click(function(){

  if(currentPage != 1)
  {
   getPage(currentPage-1);
  }
 
});    

$("#syncButton").click(function(){

 
  for (let i = 1; i <= totalPages; i++) {

  const apiCall = "https://reqres.in/api/users?page="+i;

fetch(apiCall).then(function(data)
{

  data.json().then(function(info){

    jQuery.ajax({

      type:"Post",
      url: "http://localhost:5000/api/Users/Post",
      contentType: "application/json; charset=utf-8",
      dataType: "JSON",
      data: JSON.stringify(info),
      
    
      success:function(data){
        alert("Sent Page "+ i);
      },
    
      error: function(errorThrown){
        alert("Failed To Sent Page "+ i);
      }
      });
  
  });
 
 
});

}

});    

  
