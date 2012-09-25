/*
 * NAME:	jQuery Twitter Feed Function
 * AUTHOR:	Jay Blanchard
 * DATE:	2011-09-25
 * 
 * USAGE:	Include to call tweets into a web page
 * 
 * NOTE:	Different than the function in the book, going after a certain #hashtag
 */
//$(document).ready(function() {
//   $.getJSON('http://search.twitter.com/search.json?rpp=75&callback=?&q=%40djstephaniejay' ,function(data){
//        for(var i=0;i<data.results.length;i++){
//        	var tweeter = data.results[i].from_user;
//        	var tweetText = data.results[i].text;
//        	var tweetText = tweetText.substring(0, 139);
//        	tweetText = tweetText.replace(/http:\/\/\S+/g, '<a href="$&" target="_blank">$&</a>');
//			tweetText = tweetText.replace(/(@)(\w+)/g, ' $1<a href="http://twitter.com/$2" target="_blank">$2</a>');
//			tweetText = tweetText.replace(/(#)(\w+)/g, ' $1<a href="http://search.twitter.com/search?q=%23$2" target="_blank">$2</a>');
//            $('#tw').append('<li class="tweet"><div class="tweetImage"><a href="http://twitter.com/'+tweeter+'" target="_blank"><img src="'+data.results[i].profile_image_url+'" width="48" border="0" /></a></div><div class="tweetBody">'+tweetText+'</div></li>');    
//        }
//   });
   
   function autoScroll() {
   	var itemHeight = $('#tweetlist li').outerHeight();
   		/* calculte how much to move the scroller */
       var moveFactor = parseInt($('#tweetlist').css('top')) + itemHeight;
       /* animate the carousel */
       $('#tweetlist').animate(
           {'top' : moveFactor}, 'slow', 'linear', function(){
               /* put the last item before the first item */
        	   $("#tweetlist li:first").before($("#tweetlist li:last"));
               /* reset top position */              
               $('#tweetlist').css({'top' : '-6em'});
       });
   };
   /* make the carousel scroll automatically when the page loads */
   var moveScroll = setInterval(autoScroll, 10000);
});