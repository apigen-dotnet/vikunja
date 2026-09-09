# Upstream snapshot

`vikunja.json` was exported from the official **Vikunja 2.6.0** container on
2026-09-09. Image digest:
`sha256:417ada6f94e81f0267aa2f007d0a811fc82d38dd2aa58351e3ea520ca01c2ea5`.

The checked-in release `pkg/swagger/swagger.json` lacks the required
`info.version`; the running release supplies `v2.6.0`. The public demo serves a
development build, so automatic downloads are disabled for this stable snapshot.

To export a future stable release, start its official container with an empty
SQLite database and fetch `GET /api/v1/docs.json`. For example, from the repository
root (wait for the HTTP server to start before fetching):

```bash
docker run --rm -d --name vikunja-spec-export --tmpfs /tmp \
  -p 127.0.0.1:34567:3456 \
  -e VIKUNJA_DATABASE_TYPE=sqlite \
  -e VIKUNJA_DATABASE_PATH=/tmp/vikunja.db \
  -e VIKUNJA_SERVICE_ROOTPATH=/tmp \
  -e VIKUNJA_SERVICE_PUBLICURL=http://localhost:3456 \
  vikunja/vikunja:2.6.0
curl -f http://127.0.0.1:34567/api/v1/docs.json -o specs/vikunja.json
docker stop vikunja-spec-export
```

No credentials or data from a live instance are needed. Keep the exported JSON
intact and apply SDK corrections through C# patches.
