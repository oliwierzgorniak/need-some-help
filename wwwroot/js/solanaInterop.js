window.solanaInterop = {
  connect: async () => {
    // Check if a Solana object exists (Brave, Phantom, Solflare inject this)
    const provider = window.solana;

    if (provider) {
      try {
        // Request connection to the wallet
        const response = await provider.connect();
        // Return the public key as a string
        return response.publicKey.toString();
      } catch (err) {
        console.error("User rejected the request or error occurred:", err);
        throw err;
      }
    } else {
      alert(
        "Solana wallet not found! Please install a Solana wallet extension like Phantom.",
      );
      return null;
    }
  },
};
