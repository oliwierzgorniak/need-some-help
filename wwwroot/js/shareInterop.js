window.shareInterop = {
  share: async () => {
    const shareData = {
      url: window.location.href,
    };

    // Share must be triggered by "user activation"
    try {
      await navigator.share(shareData);
      console.log("MDN shared successfully");
    } catch (err) {
      console.error(`Error: ${err}`);
    }
  },
};
