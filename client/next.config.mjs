/** @type {import('next').NextConfig} */
const nextConfig = {
    images: {
        remotePatterns: [
          {
            protocol: "http",
            hostname: "192.168.0.20",
          },
        ],
      },
};

export default nextConfig;
