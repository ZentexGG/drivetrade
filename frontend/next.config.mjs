/** @type {import('next').NextConfig} */

// You can change the API_URL environment variable inside the ".env" file
// in order to redirect to your own api

const API_URL = process.env.API_URL;

const nextConfig = {
  async rewrites() {
    return [
      {
        source: "/api/:path*",
        destination: `${API_URL}/:path*`
      },
    ];
  },
};

export default nextConfig;
