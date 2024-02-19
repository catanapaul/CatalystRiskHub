// /* this is a generic class and we have to use any */
// import { ensureMsalInitialized, msalInstance, catalystRiskHubTokenRequest } from "@/auth";

// /* eslint-disable @typescript-eslint/no-explicit-any */
// export class ClientBase {
// 	protected async transformOptions(options: RequestInit) {
// 		await ensureMsalInitialized();
// 		let account = msalInstance.getActiveAccount();
// 		if (!account) {
// 			const accounts = msalInstance.getAllAccounts();
// 			if (accounts.length && accounts[0]) {
// 				account = accounts[0];
// 			}
// 		}

// 		if (account) {
// 			const authResult = await msalInstance.acquireTokenSilent({
// 				...catalystRiskHubTokenRequest,
// 				account
// 			});

// 			const headers = new Headers(options.headers);
// 			headers.set("Authorization", `Bearer ${authResult.accessToken}`);
// 			options.headers = headers;
// 		}

// 		return Promise.resolve(options);
// 	}

// 	protected transformResult(_url: string, response: Response, processor: (response: Response) => any) {
// 		// eslint-disable-next-line @typescript-eslint/no-unsafe-return
// 		return processor(response);
// 	}
// }
