window.solanaInterop = {
  connect: async () => {
    const provider = window.solana;

    if (provider) {
      try {
        const response = await provider.connect();
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

  sendTip: async (recipientAddress, amountSol) => {
    const provider = window.solana;
    if (!provider) throw new Error("Wallet not found");

    try {
      if (!provider.isConnected) {
        await provider.connect();
      }

      const connection = new solanaWeb3.Connection(
        "https://api.devnet.solana.com",
        "confirmed",
      );

      const transaction = new solanaWeb3.Transaction();
      const recipientPubKey = new solanaWeb3.PublicKey(recipientAddress);

      const sendSolInstruction = solanaWeb3.SystemProgram.transfer({
        fromPubkey: provider.publicKey,
        toPubkey: recipientPubKey,
        lamports: amountSol * 1_000_000_000,
      });

      transaction.add(sendSolInstruction);

      const { blockhash } = await connection.getLatestBlockhash("finalized");
      transaction.recentBlockhash = blockhash;
      transaction.feePayer = provider.publicKey;

      const { signature } = await provider.signAndSendTransaction(transaction);

      return signature;
    } catch (err) {
      console.error("Transaction failed", err);
      throw err;
    }
  },
  giveReview: async (rating, reviewText) => {
    const provider = window.solana;
    if (!provider) throw new Error("Wallet not found");

    let publicKey;

    try {
      if (!provider.isConnected) {
        await provider.connect();
      }

      const connection = new solanaWeb3.Connection(
        "https://api.devnet.solana.com",
        "confirmed",
      );

      const transaction = new solanaWeb3.Transaction();

      const memoContent = `[${rating}/5] ${reviewText}`;

      const memoInstruction = new solanaWeb3.TransactionInstruction({
        keys: [],
        programId: new solanaWeb3.PublicKey(
          "MemoSq4gqABAXKb96qnH8TysNcWxMyWCqXgDLGmfcHr",
        ),
        data: new TextEncoder().encode(memoContent),
      });

      transaction.add(memoInstruction);

      const { blockhash } = await connection.getLatestBlockhash("finalized");
      transaction.recentBlockhash = blockhash;
      transaction.feePayer = provider.publicKey;

      const { signature } = await provider.signAndSendTransaction(transaction);

      return { signature: signature, publicKey: provider.publicKey.toString() };
    } catch (err) {
      console.error("Transaction failed", err);
      throw err;
    }
  },
};
