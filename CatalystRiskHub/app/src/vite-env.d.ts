/* eslint-disable @typescript-eslint/consistent-type-definitions */
/// <reference types="vite/client" />
/// <reference types="vite-plugin-svgr/client" />

interface ImportMetaEnv {
	readonly VITE_API_BASE_URL_HUB: string = "https://localhost:5001";
	// readonly VITE_API_MSFT_CLIENT_ID: string;
	// readonly VITE_API_MSFT_TENANT_ID: string;
	// readonly VITE_RECAPTCHA_SITE_KEY: string;
}

interface ImportMeta {
	readonly env: ImportMetaEnv;
}


