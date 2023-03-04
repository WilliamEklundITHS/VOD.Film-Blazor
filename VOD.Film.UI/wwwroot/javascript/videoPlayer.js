window.videoPlayer = {
    init: function (id) {
        var video = document.getElementById(id);
        video.load();
    }
};
function toggleFullScreen(videoPlayer) {
    if (!document.fullscreenElement) {
        videoPlayer.requestFullscreen();
    } else {
        if (document.exitFullscreen) {
            document.exitFullscreen();
        }
    }
}


//Youtube
function loadVideo(videoPlayerRef, videoUrl) {
    videoPlayerRef.src = videoUrl;
    videoPlayerRef.load();
}
