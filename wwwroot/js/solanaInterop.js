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

  sendTip: async (recipientAddress, amountSol) => {
    const provider = window.solana;
    if (!provider) throw new Error("Wallet not found");

    try {
      if (!provider.isConnected) {
        await provider.connect();
      }

      // 1. Establish connection to cluster (User's choice or fallback to Localhost)
      // Note: Ideally, we should let the user/app configure the endpoint passed here.
      // For this project, we hardcode localhost per requirements, but mainnet-beta is common.
      const connection = new solanaWeb3.Connection(
        "https://api.devnet.solana.com",
        "confirmed",
      );

      // 2. Create Transaction
      const transaction = new solanaWeb3.Transaction();
      const recipientPubKey = new solanaWeb3.PublicKey(recipientAddress);

      const sendSolInstruction = solanaWeb3.SystemProgram.transfer({
        fromPubkey: provider.publicKey,
        toPubkey: recipientPubKey,
        lamports: amountSol * 1_000_000_000, // Convert SOL to Lamports
      });

      transaction.add(sendSolInstruction);

      // 3. Get latest blockhash (Required for transaction to be valid)
      const { blockhash } = await connection.getLatestBlockhash();
      transaction.recentBlockhash = blockhash;
      transaction.feePayer = provider.publicKey;

      // 4. Request Signature from Wallet
      const { signature } = await provider.signAndSendTransaction(transaction);

      // 5. Confirm Transaction (Optional but recommended so UI knows it landed)
      // await connection.confirmTransaction(signature);

      return signature;
    } catch (err) {
      console.error("Transaction failed", err);
      throw err;
    }
  },
  giveReview: async (rating, reviewText) => {
    const provider = window.solana;
    if (!provider) throw new Error("Wallet not found");

    try {
      if (!provider.isConnected) {
        await provider.connect();
      }

      // 1. Establish connection to cluster
      const connection = new solanaWeb3.Connection(
        "https://api.devnet.solana.com",
        "confirmed",
      );

      // 2. Create Transaction
      const transaction = new solanaWeb3.Transaction();
      // const recipientPubKey = new solanaWeb3.PublicKey(recipientAddress); // Not sending SOL, just memo

      // Format memo: [4/5] Great service!
      const memoContent = `[${rating}/5] ${reviewText}`;

      const memoInstruction = new solanaWeb3.TransactionInstruction({
        keys: [],
        programId: new solanaWeb3.PublicKey(
          "MemoSq4gqABAXKb96qnH8TysNcWxMyWCqXgDLGmfcHr",
        ),
        data: new TextEncoder().encode(memoContent),
      });

      transaction.add(memoInstruction);

      // 3. Get latest blockhash (finalized ensures the blockhash is known by all RPC nodes)
      const { blockhash } = await connection.getLatestBlockhash("finalized");
      transaction.recentBlockhash = blockhash;
      transaction.feePayer = provider.publicKey;

      // 4. Request Signature from Wallet
      const { signature } = await provider.signAndSendTransaction(transaction);

      // 5. Confirm Transaction
      // await connection.confirmTransaction(signature);

      return signature;
    } catch (err) {
      console.error("Transaction failed", err);
      throw err;
    }
  },
};
