

$(document).ready(function(){
   
    
    
	setTimeout(function(){
		$('body').addClass('loaded');
		$('h1').css('color','#222222');
	}, 3000);
    
 $('.square3').velocity({translateX: "-50px",translateY:"70px"},{duration:10000,loop:true});
    

//     {
//            complete: function () { 
//				{ alert("123"); }
//			} 
//		} 
    
       
    var layer4Anims = [
       
        { elements : $('.square5'), properties: { translateX: "10px" }, options : {duration:300}},{
        elements : $('.square5'), properties: { translateX: "-10px" }, options : {duration:300, complete:function () {loopLayer4Anims();}}}
    ];
   
function loopLayer4Anims()
    {
        
        $.Velocity.RunSequence(layer4Anims); 
        
    }
    
    loopLayer4Anims();
    
//     $('.square5').velocity({translateX: "-150px"},{duration:100,}).velocity({translateY:"100px"},{duration:100}).velocity({translateY:"-100px"},{duration:100}).velocity({translateX:-"150px"},{duration:100});
    
    
    $(document).on("mousemove", function(event){

  var $mouseX = event.pageX,
      $mouseY = event.pageY;
   $('.square').velocity("finish");
         $('.square').velocity("stop");
         $('.square2').velocity("finish");
         $('.square2').velocity("stop");
        $('.square3parent').velocity("finish");
         $('.square3parent').velocity("stop");

        
        $('.square').velocity({translateX:($mouseX * 0.05) +"px",translateY:($mouseY * 0.05) +"px"},100);
        
                $('.square2').velocity({translateX:($mouseX * 0.10) +"px",translateY:($mouseY * 0.10) +"px"},100);
         
        
        $('.square3parent').velocity({translateX:($mouseX * 0.05) +"px",translateY:($mouseY * 0.05) +"px"},100);
//         $('.square').velocity({translateY:($mouseY * 0.05) +"px"},1);
        
});
  
    
});